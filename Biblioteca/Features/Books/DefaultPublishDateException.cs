using Biblioteca.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Features.Books
{
    public class DefaultPublishDateException : BusinessException
    {
        public DefaultPublishDateException() : base("O livro deve possuir uma data de publicação")
        {
        }
    }
}
