using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Features.Books
{
    public class Book
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Theme { get; set; }
        public string Author { get; set; }
        public int Volume { get; set; }
        public DateTime PublishDate { get; set; }
        public bool Disponibility { get; set; }

        public void Validate()
        {
            DateTime defaultDate = new DateTime();

            if (Title.Length < 4)
                throw new InvalidTitleLengthException();
            if (Theme.Length < 4)
                throw new InvalidThemeLengthException();
            if (Author.Length < 4)
                throw new InvalidAuthorLengthException();
            if (Volume < 1)
                throw new InvalidVolumeException();
            if (PublishDate == defaultDate)
                throw new DefaultPublishDateException();
        }
    }
}
