using Biblioteca.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Features.Books
{
    public class InvalidTitleLengthException : BusinessException
    {
        public InvalidTitleLengthException() : base("Título do livro deve ter pelo menos 4 caracteres")
        {
        }
    }
}
