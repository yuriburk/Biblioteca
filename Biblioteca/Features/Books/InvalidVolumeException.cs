using Biblioteca.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Features.Books
{
    public class InvalidVolumeException : BusinessException
    {
        public InvalidVolumeException() : base("O volume deve ser igual ou maior que 1")
        {
        }
    }
}
