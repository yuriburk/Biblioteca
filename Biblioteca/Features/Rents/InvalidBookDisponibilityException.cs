using Biblioteca.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Features.Rents
{
    public class InvalidBookDisponibilityException : BusinessException
    {
        public InvalidBookDisponibilityException() : base("Não pode ser feito empréstimo de um livro indisponível")
        {
        }
    }
}
