using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Exceptions
{
    public class IdentifierUndefinedException : Exception
    {
        public IdentifierUndefinedException() : base ("Id não pode ser vazio")
        {
        }
    }
}
