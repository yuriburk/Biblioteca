using Biblioteca.Applications.Features.Rents;
using Biblioteca.Common.Tests.Base;
using Biblioteca.Exceptions;
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

namespace Biblioteca.Applications.Tests.Features.Rents
{
    [TestFixture]
    public class RentServiceTest
    {
        int _invalidId = 0;
        Rent _rent;
        RentService _rentService;
        Mock<IRentRepository> _mockRentRepository;

        [SetUp]
        public void Initialize()
        {
            _rent = ObjectMother.ValidRentWithBook();
            _mockRentRepository = new Mock<IRentRepository>();
            _rentService = new RentService(_mockRentRepository.Object);
        }

        [Test]
        public void RentService_Add_ShouldBeOk()
        {
            //Cenário
            _mockRentRepository.Setup(rp => rp.Save(_rent)).Returns(_rent);

            //Ação
            Rent savedRent = _rentService.Add(_rent);

            //Verificar
            savedRent.Id.Should().Be(_rent.Id);
            _mockRentRepository.Verify(rp => rp.Save(_rent));
        }

        [Test]
        public void RentService_AddInvalidClientName_ShouldFail()
        {
            //Cenário
            _mockRentRepository.Setup(rp => rp.Save(_rent)).Returns(_rent);
            _rent = ObjectMother.InvalidRentClientWithBook();

            //Ação
            Action act = () => _rentService.Add(_rent);

            //Verificar
            act.Should().Throw<InvalidClientNameLengthException>();
            _mockRentRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void RentService_AddWithoutBook_ShouldFail()
        {
            //Cenário
            _mockRentRepository.Setup(rp => rp.Save(_rent)).Returns(_rent);
            _rent = ObjectMother.ValidRentWithoutBook();

            //Ação
            Action act = () => _rentService.Add(_rent);

            //Verificar
            act.Should().Throw<InvalidBookRentException>();
            _mockRentRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void RentService_AddUnavailableBook_ShouldFail()
        {
            //Cenário
            _mockRentRepository.Setup(rp => rp.Save(_rent)).Returns(_rent);
            _rent = ObjectMother.InvalidRentUnavailableBook();

            //Ação
            Action act = () => _rentService.Add(_rent);

            //Verificar
            act.Should().Throw<InvalidBookDisponibilityException>();
            _mockRentRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void RentService_AddDefaultReturnDate_ShouldFail()
        {
            //Cenário
            _mockRentRepository.Setup(rp => rp.Save(_rent)).Returns(_rent);
            _rent = ObjectMother.InvalidRentDefaultDateWithValidBookId();

            //Ação
            Action act = () => _rentService.Add(_rent);

            //Verificar
            act.Should().Throw<DefaultReturnDateException>();
            _mockRentRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void RentService_AddInvalidReturnDate_ShouldFail()
        {
            //Cenário
            _mockRentRepository.Setup(rp => rp.Save(_rent)).Returns(_rent);
            _rent = ObjectMother.InvalidRentInvalidDateWithValidBookId();

            //Ação
            Action act = () => _rentService.Add(_rent);

            //Verificar
            act.Should().Throw<InvalidReturnDateException>();
            _mockRentRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void RentService_Update_ShouldBeOk()
        {
            //Cenário
            _mockRentRepository.Setup(rp => rp.Update(_rent)).Returns(_rent);

            //Ação
            Rent updatedRent = _rentService.Update(_rent);

            //Verificar
            updatedRent.Id.Should().Be(_rent.Id);
            _mockRentRepository.Verify(rp => rp.Update(_rent));
        }

        [Test]
        public void RentService_UpdateInvalidClientName_ShouldFail()
        {
            //Cenário
            _mockRentRepository.Setup(rp => rp.Update(_rent)).Returns(_rent);
            _rent = ObjectMother.InvalidRentClientWithBook();

            //Ação
            Action act = () => _rentService.Update(_rent);

            //Verificar
            act.Should().Throw<InvalidClientNameLengthException>();
            _mockRentRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void RentService_UpdateWithoutBook_ShouldFail()
        {
            //Cenário
            _mockRentRepository.Setup(rp => rp.Update(_rent)).Returns(_rent);
            _rent = ObjectMother.ValidRentWithoutBook();

            //Ação
            Action act = () => _rentService.Update(_rent);

            //Verificar
            act.Should().Throw<InvalidBookRentException>();
            _mockRentRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void RentService_UpdateUnavailableBook_ShouldFail()
        {
            //Cenário
            _mockRentRepository.Setup(rp => rp.Update(_rent)).Returns(_rent);
            _rent = ObjectMother.InvalidRentUnavailableBook();

            //Ação
            Action act = () => _rentService.Update(_rent);

            //Verificar
            act.Should().Throw<InvalidBookDisponibilityException>();
            _mockRentRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void RentService_UpdateDefaultReturnDate_ShouldFail()
        {
            //Cenário
            _mockRentRepository.Setup(rp => rp.Update(_rent)).Returns(_rent);
            _rent = ObjectMother.InvalidRentDefaultDateWithValidBookId();

            //Ação
            Action act = () => _rentService.Update(_rent);

            //Verificar
            act.Should().Throw<DefaultReturnDateException>();
            _mockRentRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void RentService_UpdateInvalidReturnDate_ShouldFail()
        {
            //Cenário
            _mockRentRepository.Setup(rp => rp.Update(_rent)).Returns(_rent);
            _rent = ObjectMother.InvalidRentInvalidDateWithValidBookId();

            //Ação
            Action act = () => _rentService.Update(_rent);

            //Verificar
            act.Should().Throw<InvalidReturnDateException>();
            _mockRentRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void RentService_Delete_ShouldBeOk()
        {
            //Cenário
            _mockRentRepository.Setup(rp => rp.Delete(_rent));

            //Ação
            Action act = () => _rentService.Delete(_rent);

            //Verificar
            act.Should().NotThrow<IdentifierUndefinedException>();
            _mockRentRepository.Verify(rp => rp.Delete(_rent));
        }

        [Test]
        public void RentService_DeleteInvalidRentId_ShouldFail()
        {
            //Cenário
            _rent.Id = _invalidId;
            _mockRentRepository.Setup(rp => rp.Delete(_rent));

            //Ação
            Action act = () => _rentService.Delete(_rent);

            //Verificar
            act.Should().Throw<IdentifierUndefinedException>();
            _mockRentRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void RentService_Get_ShouldBeOk()
        {
            //Cenário
            _mockRentRepository.Setup(rp => rp.Get(_rent.Id)).Returns(_rent);

            //Ação
            Rent getRent = _rentService.Get(_rent);

            //Verificar
            getRent.Id.Should().Be(_rent.Id);
            _mockRentRepository.Verify(rp => rp.Get(_rent.Id));
        }

        [Test]
        public void RentService_GetInvalidRentId_ShouldFail()
        {
            //Cenário
            _rent.Id = _invalidId;
            _mockRentRepository.Setup(rp => rp.Get(_rent.Id)).Returns(_rent);

            //Ação
            Action act = () => _rentService.Get(_rent);

            //Verificar
            act.Should().Throw<IdentifierUndefinedException>();
            _mockRentRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void RentService_GetAll_ShouldBeOk()
        {
            //Cenário
            _mockRentRepository.Setup(rp => rp.GetAll()).Returns(new List<Rent>() { _rent });

            //Ação
            IEnumerable<Rent> rentsList = _rentService.GetAll();

            //Verificar
            rentsList.First().Id.Should().Be(_rent.Id);
            _mockRentRepository.Verify(rp => rp.GetAll());
        }
    }
}
