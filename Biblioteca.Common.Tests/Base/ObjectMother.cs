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
        public static Book ValidBookWithId()
        {
            Book book = new Book();
            book.Id = 1;
            book.Title = "Use a Cabeça C#";
            book.Theme = "Educacional";
            book.Author = "Andrew";
            book.Volume = 2;
            book.PublishDate = DateTime.Now.AddYears(-5);
            book.Disponibility = true;
            return book;
        }

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
            rent.ClientName = "Maria";
            rent.ReturnDate = DateTime.Now.AddDays(1);
            return rent;
        }

        public static Rent ValidRentWithBook()
        {
            Rent rent = new Rent();
            rent.Id = 1;
            rent.ClientName = "Maria";
            rent.Book = ValidBookWithId();
            rent.ReturnDate = DateTime.Now.AddDays(1);
            return rent;
        }

        public static Rent InvalidRentUnavailableBook()
        {
            Rent rent = new Rent();
            rent.ClientName = "Maria";
            rent.Book = new Book() { Disponibility = false };
            rent.ReturnDate = DateTime.Now.AddDays(1);
            return rent;
        }

        public static Rent InvalidRentClientName()
        {
            Rent rent = new Rent();
            rent.ClientName = "";
            rent.ReturnDate = DateTime.Now.AddDays(1);
            return rent;
        }

        public static Rent InvalidRentClientWithBook()
        {
            Rent rent = new Rent();
            rent.ClientName = "";
            rent.ReturnDate = DateTime.Now.AddDays(1);
            return rent;
        }

        public static Rent InvalidRentDefaultDate()
        {
            Rent rent = new Rent();
            rent.ClientName = "Maria";
            return rent;
        }

        public static Rent InvalidRentDefaultDateWithValidBookId()
        {
            Rent rent = new Rent();
            rent.ClientName = "Maria";
            rent.Book = ValidBookWithId();
            return rent;
        }

        public static Rent InvalidRentInvalidDate()
        {
            Rent rent = new Rent();
            rent.ClientName = "Maria";
            rent.ReturnDate = DateTime.Now.AddDays(-1);
            return rent;
        }

        public static Rent InvalidRentInvalidDateWithValidBookId()
        {
            Rent rent = new Rent();
            rent.ClientName = "Maria";
            rent.Book = ValidBookWithId();
            rent.ReturnDate = DateTime.Now.AddDays(-1);
            return rent;
        }
        #endregion
    }
}
