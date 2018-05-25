using Biblioteca.Common.Tests.Base;
using Biblioteca.Features.Books;
using Biblioteca.Features.Rents;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Domain.Tests.Features.Rents
{
    [TestFixture]
    public class RentTest
    {
        Rent _rent;
        Mock<Book> _mockBook;

        [SetUp]
        public void Initialize()
        {
            _mockBook = new Mock<Book>();
            _mockBook.Setup(b => b.Disponibility).Returns(true);
            _rent = ObjectMother.ValidRentWithoutBook();
            _rent.Books = new List<Book>() { _mockBook.Object };
        }

        [Test]
        public void Rent_ValidClientName_ShouldBeOk()
        {
            //Cenário e Ação
            Action act = () => _rent.Validate();

            //Verificar
            act.Should().NotThrow<InvalidClientNameLengthException>();
        }

        [Test]
        public void Rent_InvalidClientName_ShouldFail()
        {
            //Cenário
            _rent = ObjectMother.InvalidRentClientName();
            _rent.Books = new List<Book>() { _mockBook.Object };

            //Ação
            Action act = () => _rent.Validate();

            //Verificar
            act.Should().Throw<InvalidClientNameLengthException>();
        }

        [Test]
        public void Rent_AvailableBook_ShouldBeOk()
        {
            //Cenário e Ação
            Action act = () => _rent.Validate();

            //Verificar
            act.Should().NotThrow<InvalidBookDisponibilityException>();
        }

        [Test]
        public void Rent_UnavailableBook_ShouldFail()
        {
            //Cenário
            _mockBook.Setup(b => b.Disponibility).Returns(false);

            //Ação
            Action act = () => _rent.Validate();

            //Verificar
            act.Should().Throw<InvalidBookDisponibilityException>();
        }

        [Test]
        public void Rent_WithoutBook_ShouldFail()
        {
            //Cenário
            _rent = ObjectMother.ValidRentWithoutBook();

            //Ação
            Action act = () => _rent.Validate();

            //Verificar
            act.Should().Throw<InvalidBookRentException>();
        }

        [Test]
        public void Rent_ValidReturnDate_ShouldBeOk()
        {
            //Cenário e Ação
            Action act = () => _rent.Validate();

            //Verificar
            act.Should().NotThrow<DefaultReturnDateException>();
            act.Should().NotThrow<InvalidReturnDateException>();
        }

        [Test]
        public void Rent_DefaultReturnDate_ShouldFail()
        {
            //Cenário
            _rent = ObjectMother.InvalidRentDefaultDate();
            _rent.Books = new List<Book>() { _mockBook.Object };

            //Ação
            Action act = () => _rent.Validate();

            //Verificar
            act.Should().Throw<DefaultReturnDateException>();
        }

        [Test]
        public void Rent_InvalidReturnDate_ShouldFail()
        {
            //Cenário
            _rent = ObjectMother.InvalidRentInvalidDate();
            _rent.Books = new List<Book>() { _mockBook.Object };

            //Ação
            Action act = () => _rent.Validate();

            //Verificar
            act.Should().Throw<InvalidReturnDateException>();
        }

        [Test]
        public void TearDown()
        {
            _rent = null;
            _mockBook = null;
        }
    }
}
