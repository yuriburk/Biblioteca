using Biblioteca.Features.Books;
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
            book.Author = "Andrew e Jennifer";
            book.Volume = 2;
            book.PublishDate = DateTime.Now.AddYears(-5);
            book.Disponibility = true;
            return book;
        }
        #endregion
    }
}
