using Biblioteca.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Features.Books
{
    public class InvalidThemeLengthException : BusinessException
    {
        public InvalidThemeLengthException() : base("Tema do livro deve ter pelo menos 4 caracteres")
        {
        }
    }
}
