using Biblioteca.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Features.Rents
{
    public class InvalidReturnDateException : BusinessException
    {
        public InvalidReturnDateException() : base("A data de retorno do empréstimo deve ser maior que a data de realização")
        {
        }
    }
}
