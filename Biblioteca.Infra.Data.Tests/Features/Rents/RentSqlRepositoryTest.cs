using Biblioteca.Common.Tests.Base;
using Biblioteca.Exceptions;
using Biblioteca.Features.Rents;
using Biblioteca.Infra.Data.Features.Rents;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Infra.Data.Tests.Features.Rents
{
    [TestFixture]
    public class RentSqlRepositoryTest
    {
        int _seedId = 1;
        int _invalidId = 0;

        Rent _rent;
        IRentRepository _rentRepository;

        [SetUp]
        public void Initialize()
        {
            BaseSqlTest.SeedDataBase();
            _rent = ObjectMother.ValidRentWithBook();
            _rentRepository = new RentSqlRepository();
        }

        [Test]
        public void RentSqlRepository_Add_ShouldBeOk()
        {
            //Ação e Cenário
            Rent savedRent = _rentRepository.Save(_rent);

            //Verificar
            savedRent.Id.Should().Be(_rent.Id);
            savedRent.Books.First().Id.Should().Be(_rent.Books.First().Id);
        }

        [Test]
        public void RentSqlRepository_AddInvalidClient_ShouldFail()
        {
            //Cenário
            _rent = ObjectMother.InvalidRentClientName();

            //Ação
            Action act = () => _rentRepository.Save(_rent);

            //Verificar
            act.Should().Throw<InvalidClientNameLengthException>();
        }

        [Test]
        public void RentSqlRepository_AddInvalidBooks_ShouldFail()
        {
            //Cenário
            _rent = ObjectMother.ValidRentWithoutBook();

            //Ação
            Action act = () => _rentRepository.Save(_rent);

            //Verificar
            act.Should().Throw<InvalidBookRentException>();
        }

        [Test]
        public void RentSqlRepository_AddUnavailableBook_ShouldFail()
        {
            //Cenário
            _rent = ObjectMother.InvalidRentUnavailableBook();

            //Ação
            Action act = () => _rentRepository.Save(_rent);

            //Verificar
            act.Should().Throw<InvalidBookDisponibilityException>();
        }

        [Test]
        public void RentSqlRepository_AddDefaultDate_ShouldFail()
        {
            //Cenário
            _rent = ObjectMother.InvalidRentDefaultDate();

            //Ação
            Action act = () => _rentRepository.Save(_rent);

            //Verificar
            act.Should().Throw<DefaultReturnDateException>();
        }

        [Test]
        public void RentSqlRepository_AddInvalidDate_ShouldFail()
        {
            //Cenário
            _rent = ObjectMother.InvalidRentInvalidDate();

            //Ação
            Action act = () => _rentRepository.Save(_rent);

            //Verificar
            act.Should().Throw<InvalidReturnDateException>();
        }

        [Test]
        public void RentSqlRepository_Update_ShouldBeOk()
        {
            //Cenário e Ação
            _rent.Id = _seedId;
            Rent updatedRent = _rentRepository.Update(_rent);

            //Verificar
            updatedRent.Id.Should().Be(_rent.Id);
            updatedRent.Books.First().Id.Should().Be(_rent.Books.First().Id);
        }

        [Test]
        public void RentSqlRepository_UpdateInvalidClient_ShouldFail()
        {
            //Cenário
            _rent = ObjectMother.InvalidRentClientName();
            _rent.Id = _seedId;

            //Ação
            Action act = () => _rentRepository.Update(_rent);

            //Verificar
            act.Should().Throw<InvalidClientNameLengthException>();
        }

        [Test]
        public void RentSqlRepository_UpdateInvalidBooks_ShouldFail()
        {
            //Cenário
            _rent = ObjectMother.ValidRentWithoutBook();
            _rent.Id = _seedId;

            //Ação
            Action act = () => _rentRepository.Update(_rent);

            //Verificar
            act.Should().Throw<InvalidBookRentException>();
        }

        [Test]
        public void RentSqlRepository_UpdateUnavailableBook_ShouldFail()
        {
            //Cenário
            _rent = ObjectMother.InvalidRentUnavailableBook();
            _rent.Id = _seedId;

            //Ação
            Action act = () => _rentRepository.Update(_rent);

            //Verificar
            act.Should().Throw<InvalidBookDisponibilityException>();
        }

        [Test]
        public void RentSqlRepository_UpdateDefaultDate_ShouldFail()
        {
            //Cenário
            _rent = ObjectMother.InvalidRentDefaultDate();
            _rent.Id = _seedId;

            //Ação
            Action act = () => _rentRepository.Update(_rent);

            //Verificar
            act.Should().Throw<DefaultReturnDateException>();
        }

        [Test]
        public void RentSqlRepository_UpdateInvalidDate_ShouldFail()
        {
            //Cenário
            _rent = ObjectMother.InvalidRentInvalidDate();
            _rent.Id = _seedId;

            //Ação
            Action act = () => _rentRepository.Update(_rent);

            //Verificar
            act.Should().Throw<InvalidReturnDateException>();
        }

        [Test]
        public void RentSqlRepository_Get_ShouldBeOk()
        {
            //Cenário e Ação
            Rent getRent = _rentRepository.Get(_seedId);

            //Verificar
            getRent.Should().NotBeNull();
            getRent.Id.Should().Be(_seedId);
        }

        [Test]
        public void RentSqlRepository_GetInvalidId_ShouldFail()
        {
            //Cenário e Ação
            Action act = () => _rentRepository.Get(_invalidId);

            //Verificar
            act.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        public void RentSqlRepository_Delete_ShouldBeOk()
        {
            //Cenário e Ação
            _rent = ObjectMother.ValidRentWithoutBook();
            int validRentWithoutBook = 2;
            _rent.Id = validRentWithoutBook;
            _rentRepository.Delete(_rent);

            //Verificar
            _rentRepository.Get(_rent.Id).Should().BeNull();
        }

        [Test]
        public void RentSqlRepository_DeleteInvalidId_ShouldFail()
        {
            //Cenário e Ação
            _rent.Id = _invalidId;
            Action act = () => _rentRepository.Delete(_rent);

            //Verificar
            act.Should().Throw<IdentifierUndefinedException>();
        }
        
        [Test]
        public void RentSqlRepository_DeleteWithBook_ShouldFail()
        {
            //Cenário e Ação
            Action act = () => _rentRepository.Delete(_rent);

            //Verificar
            act.Should().Throw<RentWithBookException>();
        }

        [Test]
        public void RentSqlRepository_GetAll_ShouldBeOk()
        {
            //Cenário e Ação
            IEnumerable<Rent> rentList = _rentRepository.GetAll();

            //Verificar
            rentList.Should().NotBeNull();
            rentList.First().Id.Should().Be(_seedId);
        }
    }
}
