using Biblioteca.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Features.Rents
{
    public class InvalidBookRentException : BusinessException
    {
        public InvalidBookRentException() : base("O empréstimo deve conter pelo menos um livro")
        {
        }
    }
}
