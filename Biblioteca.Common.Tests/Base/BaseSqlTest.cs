using Biblioteca.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Common.Tests.Base
{
    public static class BaseSqlTest
    {
        private const string RECREATE_RENT_BOOK_TABLE = "TRUNCATE TABLE [dbo].[TBEmprestimo_Livro]";
        private const string RECREATE_BOOK_TABLE = "DELETE FROM [dbo].[TBLivro] DBCC CHECKIDENT('TBLivro', RESEED, 0)";
        private const string RECREATE_RENT_TABLE = "DELETE FROM [dbo].[TBEmprestimo] DBCC CHECKIDENT('TBEmprestimo', RESEED, 0)";
        private const string INSERT_BOOK_TABLE = "INSERT INTO TBLivro VALUES ('Livro', 'Comédia', 'João', '1', GETDATE(), '0')";
        private const string INSERT_RENT_TABLE = "INSERT INTO TBEmprestimo VALUES ('João', GETDATE())";
        private const string INSERT_RENT_WITHOUTBOOK_TABLE = "INSERT INTO TBEmprestimo VALUES ('Emprestimo sem livro', GETDATE())";
        private const string INSERT_RENT_BOOK_TABLE = "INSERT INTO TBEmprestimo_Livro VALUES (1, 1)";

        public static void SeedDataBase()
        {
            Db.Update(RECREATE_RENT_BOOK_TABLE);
            Db.Update(RECREATE_BOOK_TABLE);
            Db.Update(RECREATE_RENT_TABLE);
            Db.Update(INSERT_BOOK_TABLE);
            Db.Update(INSERT_RENT_TABLE);
            Db.Update(INSERT_RENT_BOOK_TABLE);
            Db.Update(INSERT_RENT_WITHOUTBOOK_TABLE);
        }
    }
}
