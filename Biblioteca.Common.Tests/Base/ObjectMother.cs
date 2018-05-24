using Biblioteca.Features.Books;
using Biblioteca.Features.Rents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Common.Tests.Base
{
    public static partial class ObjectMother
    {
        #region Book
        public static Book ValidBookWithoutId()
        {
            Book book = new Book();
            book.Title = "Use a Cabeça C#";
            book.Theme = "Educacional";
            book.Author = "Andrew";
            book.Volume = 2;
            book.PublishDate = DateTime.Now.AddYears(-5);
            book.Disponibility = true;
            return book;
        }

        public static Book InvalidBookTitleWithoutId()
        {
            Book book = new Book();
            book.Title = "Use";
            book.Theme = "Educacional";
            book.Author = "Andrew";
            book.Volume = 2;
            book.PublishDate = DateTime.Now.AddYears(-5);
            book.Disponibility = true;
            return book;
        }

        public static Book InvalidBookThemeWithoutId()
        {
            Book book = new Book();
            book.Title = "Use a Cabeça C#";
            book.Theme = "Ed";
            book.Author = "Andrew";
            book.Volume = 2;
            book.PublishDate = DateTime.Now.AddYears(-5);
            book.Disponibility = true;
            return book;
        }

        public static Book InvalidBookAuthorWithoutId()
        {
            Book book = new Book();
            book.Title = "Use a Cabeça C#";
            book.Theme = "Educacional";
            book.Author = "A";
            book.Volume = 2;
            book.PublishDate = DateTime.Now.AddYears(-5);
            book.Disponibility = true;
            return book;
        }

        public static Book InvalidBookVolumeWithoutId()
        {
            Book book = new Book();
            book.Title = "Use a Cabeça C#";
            book.Theme = "Educacional";
            book.Author = "Andrew";
            book.Volume = 0;
            book.PublishDate = DateTime.Now.AddYears(-5);
            book.Disponibility = true;
            return book;
        }

        public static Book InvalidBookDateWithoutId()
        {
            Book book = new Book();
            book.Title = "Use a Cabeça C#";
            book.Theme = "Educacional";
            book.Author = "Andrew";
            book.Volume = 2;
            book.Disponibility = true;
            return book;
        }
        #endregion

        #region Rent
        public static Rent ValidRentWithoutBook()
        {
            Rent rent = new Rent();
            rent.ClientName = "Yuri";
            rent.ReturnDate = DateTime.Now.AddDays(1);
            return rent;
        }
        #endregion
    }
}
