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
        public long Id { get; set; }
        public string ClientName { get; set; }
        public virtual Book Book { get; set; }
        public DateTime ReturnDate { get; set; }

        public void Validate()
        {
            DateTime defaultDate = new DateTime();

            if (ClientName.Length < 4)
                throw new InvalidClientNameLengthException();
            if (Book == null)
                throw new InvalidBookRentException();
            if (!Book.Disponibility)
                throw new InvalidBookDisponibilityException();
            if (ReturnDate == defaultDate)
                throw new DefaultReturnDateException();
            if (ReturnDate <= DateTime.Now)
                throw new InvalidReturnDateException();
        }
    }
}
