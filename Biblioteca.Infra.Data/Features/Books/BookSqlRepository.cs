using Biblioteca.Exceptions;
using Biblioteca.Features.Books;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Infra.Data.Features.Books
{
    public class BookSqlRepository : IBookRepository
    {
        #region SQL Script
        private const string _sqlInsertBook = @"INSERT INTO TBLivro
                                                VALUES (@Titulo, @Tema, @Autor, @Volume, @DataPublicacao, @Disponivel)";
        private const string _sqlUpdateBook = @"UPDATE TBLivro
                                                SET
                                                    Titulo = @Titulo,
                                                    Tema = @Tema,
                                                    Autor = @Autor,
                                                    Volume = @Volume,
                                                    DataPublicacao = @DataPublicacao
                                                    Disponivel = @Disponivel
                                                WHERE
                                                    IdLivro = @IdLivro";
        private const string _sqlGetById = @"SELECT IdLivro, Titulo, Tema, Autor, Volume, DataPublicacao, Disponivel FROM TBLivro
                                                WHERE IdLivro = @IdLivro";
        private const string _sqlGetAll = @"SELECT IdLivro, Titulo, Tema, Autor, Volume, DataPublicacao, Disponivel FROM TBLivro";
        private const string _sqlDeleteBook = @"DELETE FROM TBLivro
                                                WHERE IdLivro = @IdLivro";
        #endregion

        public void Delete(Book book)
        {
            if (book.Id == 0)
                throw new IdentifierUndefinedException();

            var parms = new object[] { "IdLivro", book.Id };

            Db.Delete(_sqlDeleteBook, parms);
        }

        public Book Get(long id)
        {
            if (id == 0)
                throw new IdentifierUndefinedException();

            var parms = new object[] { "IdLivro", id };
            return Db.Get(_sqlGetById, Make, parms);
        }

        public IEnumerable<Book> GetAll()
        {
            return Db.GetAll(_sqlGetAll, Make);
        }

        public Book Save(Book book)
        {
            book.Validate();
            book.Id = Db.Insert(_sqlInsertBook, Take(book));

            return book;
        }

        public Book Update(Book book)
        {
            book.Validate();
            Db.Update(_sqlUpdateBook, Take(book));

            return book;
        }

        private static Func<IDataReader, Book> Make = reader =>
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

        private object[] Take(Book book)
        {
            return new object[]
            {
                "@IdLivro", book.Id,
                "@Titulo", book.Title,
                "@Tema", book.Theme,
                "@Autor", book.Author,
                "@Volume", book.Volume,
                "@DataPublicacao", book.PublishDate,
                "@Disponivel", book.Disponibility
            };
        }
    }
}
