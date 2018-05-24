using Biblioteca.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Features.Rents
{
    public class DefaultReturnDateException : BusinessException
    {
        public DefaultReturnDateException() : base("O empréstimo deve possuir uma data de retorno")
        {
        }
    }
}
