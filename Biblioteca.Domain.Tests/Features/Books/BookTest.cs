using Biblioteca.Common.Tests.Base;
using Biblioteca.Exceptions;
using Biblioteca.Features.Books;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Domain.Tests.Features.Books
{
    [TestFixture]
    public class BookTest
    {
        Book _book;

        [SetUp]
        public void Initialize()
        {
            _book = new Book();
        }

        [Test]
        public void Book_ValidFields_ShouldBeOk()
        {
            //Cenário
            _book = ObjectMother.ValidBookWithoutId();

            //Ação
            Action act = () => _book.Validate();

            //Verificar
            act.Should().NotThrow<BusinessException>();
        }
    }
}
