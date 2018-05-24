using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Features.Books
{
    public class Book
    {
        public string Title { get; set; }
        public string Theme { get; set; }
        public string Author { get; set; }
        public int Volume { get; set; }
        public DateTime PublishDate { get; set; }
        public bool Disponibility { get; set; }

        public void Validate()
        {
            if (Title.Length < 4)
                throw new Exception();
            if (Theme.Length < 4)
                throw new Exception();
            if (Author.Length < 4)
                throw new Exception();
            if (Volume < 1)
                throw new Exception();
            if (PublishDate == null)
                throw new Exception();
        }
    }
}
