using Biblioteca.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Features.Rents
{
    public class InvalidClientNameLengthException : BusinessException
    {
        public InvalidClientNameLengthException() : base("Nome do cliente deve ter pelo menos 4 caracteres")
        {
        }
    }
}
