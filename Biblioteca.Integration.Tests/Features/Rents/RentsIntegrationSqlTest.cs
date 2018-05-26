using Biblioteca.Applications.Features.Rents;
using Biblioteca.Common.Tests.Base;
using Biblioteca.Exceptions;
using Biblioteca.Features.Books;
using Biblioteca.Features.Rents;
using Biblioteca.Infra.Data.Features.Books;
using Biblioteca.Infra.Data.Features.Rents;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Integration.Tests.Features.Rents
{
    [TestFixture]
    public class RentsIntegrationSqlTest
    {
        int _seedId = 1;
        int _invalidId = 0;

        Book _book;
        Rent _rent;
        IRentRepository _rentRepository;
        RentService _rentService;

        [SetUp]
        public void Initialize()
        {
            BaseSqlTest.SeedDataBase();
            _book = ObjectMother.ValidBookWithId();
            _rent = ObjectMother.ValidRentWithoutId();
            _rentRepository = new RentSqlRepository();
            _rentService = new RentService(_rentRepository);
        }

        [Test]
        public void RentIntegrationSql_Add_ShouldBeOk()
        {
            //Cenário e Ação
            Rent savedRent = _rentService.Add(_rent);

            //Verificar
            savedRent.Id.Should().Be(_rent.Id);
        }

        [Test]
        public void RentIntegrationSql_AddInvalidClientName_ShouldFail()
        {
            //Cenário
            _rent = ObjectMother.InvalidRentClientWithBook();

            //Ação
            Action act = () => _rentService.Add(_rent);

            //Verificar
            act.Should().Throw<InvalidClientNameLengthException>();
        }

        [Test]
        public void RentIntegrationSql_AddWithoutBook_ShouldFail()
        {
            //Cenário
            _rent = ObjectMother.ValidRentWithoutBook();

            //Ação
            Action act = () => _rentService.Add(_rent);

            //Verificar
            act.Should().Throw<InvalidBookRentException>();
        }

        [Test]
        public void RentIntegrationSql_AddUnavailableBook_ShouldFail()
        {
            //Cenário
            _rent = ObjectMother.InvalidRentUnavailableBook();

            //Ação
            Action act = () => _rentService.Add(_rent);

            //Verificar
            act.Should().Throw<InvalidBookDisponibilityException>();
        }

        [Test]
        public void RentIntegrationSql_AddDefaultReturnDate_ShouldFail()
        {
            //Cenário
            _rent = ObjectMother.InvalidRentDefaultDateWithValidBookId();

            //Ação
            Action act = () => _rentService.Add(_rent);

            //Verificar
            act.Should().Throw<DefaultReturnDateException>();
        }

        [Test]
        public void RentIntegrationSql_AddInvalidReturnDate_ShouldFail()
        {
            //Cenário
            _rent = ObjectMother.InvalidRentInvalidDateWithValidBookId();

            //Ação
            Action act = () => _rentService.Add(_rent);

            //Verificar
            act.Should().Throw<InvalidReturnDateException>();
        }

        [Test]
        public void RentIntegrationSql_Update_ShouldBeOk()
        {
            //Cenário e Ação
            Rent updatedRent = _rentService.Update(_rent);

            //Verificar
            updatedRent.Id.Should().Be(_rent.Id);
        }

        [Test]
        public void RentIntegrationSql_UpdateAvailableToUnavailable_ShouldBeOk()
        {
            //Cenário
            _book = ObjectMother.AnotherValidBookWithId();
            _rent.Id = _seedId;
            _rent.Books.Add(_book);

            //Ação
            Rent updatedRent = _rentService.Update(_rent);

            //Verificar
            updatedRent.Books.Count.Should().Be(_rent.Books.Count);
        }

        [Test]
        public void RentIntegrationSql_UpdateUnavailableToAvailable_ShouldBeOk()
        {
            //Cenário
            _book = ObjectMother.AnotherValidBookWithId();
            _rent.Id = _seedId;
            _rent.Books = new List<Book>() { _book };

            //Ação
            Rent updatedRent = _rentService.Update(_rent);

            //Verificar
            updatedRent.Books.Count.Should().Be(_rent.Books.Count);
        }

        [Test]
        public void RentIntegrationSql_UpdateRentWithNoBook_ShouldFail()
        {
            //Cenário
            _rent.Id = _seedId;
            _rent.Books = new List<Book>();

            //Ação
            Action act = () => _rentService.Update(_rent);

            //Verificar
            act.Should().Throw<InvalidBookRentException>();
        }

        [Test]
        public void RentIntegrationSql_UpdateInvalidClientName_ShouldFail()
        {
            //Cenário
            _rent = ObjectMother.InvalidRentClientWithBook();

            //Ação
            Action act = () => _rentService.Update(_rent);

            //Verificar
            act.Should().Throw<InvalidClientNameLengthException>();
        }

        [Test]
        public void RentIntegrationSql_UpdateUnavailableBook_ShouldFail()
        {
            //Cenário
            _rent = ObjectMother.InvalidRentUnavailableBook();

            //Ação
            Action act = () => _rentService.Update(_rent);

            //Verificar
            act.Should().Throw<InvalidBookDisponibilityException>();
        }

        [Test]
        public void RentIntegrationSql_UpdateDefaultReturnDate_ShouldFail()
        {
            //Cenário
            _rent = ObjectMother.InvalidRentDefaultDateWithValidBookId();

            //Ação
            Action act = () => _rentService.Update(_rent);

            //Verificar
            act.Should().Throw<DefaultReturnDateException>();
        }

        [Test]
        public void RentIntegrationSql_UpdateInvalidReturnDate_ShouldFail()
        {
            //Cenário
            _rent = ObjectMother.InvalidRentInvalidDateWithValidBookId();

            //Ação
            Action act = () => _rentService.Update(_rent);

            //Verificar
            act.Should().Throw<InvalidReturnDateException>();
        }

        [Test]
        public void RentIntegrationSql_Delete_ShouldBeOk()
        {
            //Cenário e Ação
            Action act = () => _rentService.Delete(_rent);

            //Verificar
            act.Should().NotThrow<IdentifierUndefinedException>();
        }

        [Test]
        public void RentIntegrationSql_DeleteInvalidRentId_ShouldFail()
        {
            //Cenário
            _rent.Id = _invalidId;
           
            //Ação
            Action act = () => _rentService.Delete(_rent);

            //Verificar
            act.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        public void RentIntegrationSql_Get_ShouldBeOk()
        {
            //Cenário e Ação
            Rent getRent = _rentService.Get(_rent);

            //Verificar
            getRent.Id.Should().Be(_rent.Id);
        }

        [Test]
        public void RentIntegrationSql_GetInvalidRentId_ShouldFail()
        {
            //Cenário
            _rent.Id = _invalidId;

            //Ação
            Action act = () => _rentService.Get(_rent);

            //Verificar
            act.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        public void RentIntegrationSql_GetAll_ShouldBeOk()
        {
            //Cenário e Ação
            IEnumerable<Rent> rentsList = _rentService.GetAll();

            //Verificar
            rentsList.First().Id.Should().Be(_rent.Id);
        }
    }
}
