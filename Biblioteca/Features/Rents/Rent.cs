using Biblioteca.Features.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Features.Rents
{
    public class Rent
    {
        public int Id { get; set; }
        public string ClientName { get; set; }
        public virtual List<Book> Books { get; set; }
        public DateTime ReturnDate { get; set; }
        public double Fine => GetFine();

        public void Validate()
        {
            DateTime defaultDate = new DateTime();

            if (ClientName.Length < 4)
                throw new InvalidClientNameLengthException();
            foreach (Book b in Books)
            {
                if (!b.Disponibility)
                    throw new InvalidBookDisponibilityException();
            }
            if (ReturnDate == defaultDate)
                throw new DefaultReturnDateException();
            if (ReturnDate <= DateTime.Now)
                throw new InvalidReturnDateException();
        }

        private double GetFine()
        {
            double fine = 0;

            if (DateTime.Now > ReturnDate)
            {
                TimeSpan timeDifference = DateTime.Now - ReturnDate;
                fine = timeDifference.Days * 2.5;
            }

            return fine;
        }
    }
}
