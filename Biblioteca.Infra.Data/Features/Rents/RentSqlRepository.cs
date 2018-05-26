using Biblioteca.Exceptions;
using Biblioteca.Features.Books;
using Biblioteca.Features.Rents;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Infra.Data.Features.Rents
{
    public class RentSqlRepository : IRentRepository
    {
        #region SQL Script
        private const string _sqlInsertRent = @"INSERT INTO TBEmprestimo
                                                VALUES (@NomeCliente, @DataDevolucao)";
        private const string _sqlUpdateBookInRent = @"UPDATE TBLivro
                                                    SET Disponivel = 0
                                                    FROM TBLivro AS L
                                                    INNER JOIN TBEmprestimo_Livro AS EL
                                                    ON EL.Emprestimo_Id = @IdEmprestimo";
        private const string _sqlUpdateBookNotInRent = @"UPDATE TBLivro
                                                    SET Disponivel = 1
                                                    FROM TBLivro AS L
                                                    INNER JOIN TBEmprestimo_Livro AS EL
                                                    ON EL.Livro_Id = @IdLivro
                                                    DELETE EL FROM TBEmprestimo_Livro AS EL
                                                    INNER JOIN TBLivro AS L
                                                    ON L.IdLivro = @IdLivro";
        private const string _sqlUpdateRent = @"UPDATE TBEmprestimo
                                                SET
                                                    NomeCliente = @NomeCliente,
                                                    DataDevolucao = @DataDevolucao
                                                WHERE
                                                    IdEmprestimo = @IdEmprestimo";
        private const string _sqlGetById = @"SELECT 
                                                E.IdEmprestimo,
                                                E.NomeCliente,
                                                E.DataDevolucao,
                                                L.IdLivro,
                                                L.Titulo,
                                                L.Tema,
                                                L.Autor,
                                                L.Volume,
                                                L.DataPublicacao,
                                                L.Disponivel
                                            FROM TBEmprestimo AS E
                                            INNER JOIN TBEmprestimo_Livro AS EL
                                            ON EL.Emprestimo_Id = E.IdEmprestimo
                                            INNER JOIN TBLivro AS L
                                            ON EL.Livro_Id = L.IdLivro
                                            WHERE IdEmprestimo = @IdEmprestimo";
        private const string _sqlGetBooksInRent = @"SELECT
                                                L.IdLivro,
                                                L.Titulo,
                                                L.Tema,
                                                L.Autor,
                                                L.Volume,
                                                L.DataPublicacao,
                                                L.Disponivel
                                            FROM TBLivro AS L
                                            INNER JOIN TBEmprestimo_Livro AS EL
                                            ON EL.Livro_Id = L.IdLivro
                                            INNER JOIN TBEmprestimo AS E
                                            ON EL.Emprestimo_Id = E.IdEmprestimo
                                            WHERE E.IdEmprestimo = @IdEmprestimo";
        private const string _sqlGetAll = @"SELECT 
                                                E.IdEmprestimo,
                                                E.NomeCliente,
                                                E.DataDevolucao,
                                                L.IdLivro,
                                                L.Titulo,
                                                L.Tema,
                                                L.Autor,
                                                L.Volume,
                                                L.DataPublicacao,
                                                L.Disponivel
                                            FROM TBEmprestimo AS E
                                            INNER JOIN TBEmprestimo_Livro AS EL
                                            ON EL.Emprestimo_Id = E.IdEmprestimo
                                            INNER JOIN TBLivro AS L
                                            ON EL.Livro_Id = L.IdLivro";
        private const string _sqlDeleteRent = @"DELETE FROM TBEmprestimo
                                                WHERE IdEmprestimo = @IdEmprestimo";
        #endregion

        public void Delete(Rent rent)
        {
            if (rent.Id == 0)
                throw new IdentifierUndefinedException();

            if (rent.Books.Count > 0)
                throw new RentWithBookException();

            var parms = new object[] { "IdEmprestimo", rent.Id };
            Db.Delete(_sqlDeleteRent, parms);
        }

        public Rent Get(long id)
        {
            if (id == 0)
                throw new IdentifierUndefinedException();

            var parms = new object[] { "IdEmprestimo", id };
            return Db.Get(_sqlGetById, Make, parms);
        }

        public IEnumerable<Rent> GetAll()
        {
            return Db.GetAll(_sqlGetAll, Make);
        }

        public Rent Save(Rent rent)
        {
            rent.Validate();
            rent.Id = Db.Insert(_sqlInsertRent, Take(rent));
            var parms = new object[] { "IdEmprestimo", rent.Id };
            Db.Update(_sqlUpdateBookInRent, parms);
            return rent;
        }

        public Rent Update(Rent rent)
        {
            rent.Validate();
            List<Book> booksRent = GetBooksFromRent(rent.Id);
            Db.Update(_sqlUpdateRent, Take(rent));
            foreach (Book bookInOutdatedRent in booksRent)
            {
                foreach (Book bookInUpdatedRent in rent.Books)
                {
                    if (bookInUpdatedRent.Id != bookInOutdatedRent.Id)
                    {
                        var parms = new object[] { "IdLivro", bookInOutdatedRent.Id };
                        Db.Update(_sqlUpdateBookNotInRent, parms);
                    }
                }
            }

            return rent;
        }

        private static Func<IDataReader, Rent> Make = reader =>
           new Rent
           {
               Id = Convert.ToInt32(reader["IdEmprestimo"]),
               ClientName = Convert.ToString(reader["NomeCliente"]),
               Books = GetBooksFromRent(Convert.ToInt32(reader["IdEmprestimo"])),
               ReturnDate = Convert.ToDateTime(reader["DataDevolucao"])
           };

        private static Func<IDataReader, Book> MakeBooks = reader =>
           new Book
           {
               Id = Convert.ToInt32(reader["IdLivro"]),
               Title = Convert.ToString(reader["Titulo"]),
               Theme = Convert.ToString(reader["Tema"]),
               Author = Convert.ToString(reader["Autor"]),
               Volume = Convert.ToInt32(reader["Volume"]),
               PublishDate = Convert.ToDateTime(reader["DataPublicacao"]),
               Disponibility = Convert.ToBoolean(reader["Disponivel"])
           };

        private static List<Book> GetBooksFromRent(int rentId)
        {
            var parms = new object[] { "IdEmprestimo", rentId };
            return Db.GetAll(_sqlGetBooksInRent, MakeBooks, parms).ToList();
        }

        private object[] Take(Rent rent)
        {
            return new object[]
            {
                "@IdEmprestimo", rent.Id,
                "@NomeCliente", rent.ClientName,
                "@DataDevolucao", rent.ReturnDate
            };
        }
    }
}
