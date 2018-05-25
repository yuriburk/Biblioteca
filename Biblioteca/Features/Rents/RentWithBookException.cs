using Biblioteca.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Features.Rents
{
    public class RentWithBookException : BusinessException
    {
        public RentWithBookException() : base("Não pode deletar um empréstimo que contenha um livros")
        {
        }
    }
}
