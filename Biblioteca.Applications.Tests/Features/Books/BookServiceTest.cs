using Biblioteca.Applications.Features.Books;
using Biblioteca.Common.Tests.Base;
using Biblioteca.Exceptions;
using Biblioteca.Features.Books;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Applications.Tests.Features.Books
{
    [TestFixture]
    public class BookServiceTest
    {
        int _invalidId = 0;

        Book _book;
        BookService _bookService;
        Mock<IBookRepository> _mockBookRepository;

        [SetUp]
        public void Initialize()
        {
            _book = ObjectMother.ValidBookWithId();
            _mockBookRepository = new Mock<IBookRepository>();
            _bookService = new BookService(_mockBookRepository.Object);
        }

        [Test]
        public void BookService_Add_ShouldBeOk()
        {
            //Cenário
            _mockBookRepository.Setup(rp => rp.Save(_book)).Returns(_book);

            //Ação
            Book savedBook = _bookService.Add(_book);

            //Verificar
            savedBook.Should().NotBeNull();
            savedBook.Id.Should().Be(_book.Id);
            _mockBookRepository.Verify(rp => rp.Save(_book));
        }

        [Test]
        public void BookService_AddInvalidTitle_ShouldFail()
        {
            //Cenário
            _mockBookRepository.Setup(rp => rp.Save(_book)).Returns(_book);
            _book = ObjectMother.InvalidBookTitleWithoutId();

            //Ação
            Action act = () => _bookService.Add(_book);

            //Verificar
            act.Should().Throw<InvalidTitleLengthException>();
            _mockBookRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void BookService_AddInvalidTheme_ShouldFail()
        {
            //Cenário
            _mockBookRepository.Setup(rp => rp.Save(_book)).Returns(_book);
            _book = ObjectMother.InvalidBookThemeWithoutId();

            //Ação
            Action act = () => _bookService.Add(_book);

            //Verificar
            act.Should().Throw<InvalidThemeLengthException>();
            _mockBookRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void BookService_AddInvalidAuthor_ShouldFail()
        {
            //Cenário
            _mockBookRepository.Setup(rp => rp.Save(_book)).Returns(_book);
            _book = ObjectMother.InvalidBookAuthorWithoutId();

            //Ação
            Action act = () => _bookService.Add(_book);

            //Verificar
            act.Should().Throw<InvalidAuthorLengthException>();
            _mockBookRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void BookService_AddInvalidVolume_ShouldFail()
        {
            //Cenário
            _mockBookRepository.Setup(rp => rp.Save(_book)).Returns(_book);
            _book = ObjectMother.InvalidBookVolumeWithoutId();

            //Ação
            Action act = () => _bookService.Add(_book);

            //Verificar
            act.Should().Throw<InvalidVolumeException>();
            _mockBookRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void BookService_AddInvalidDate_ShouldFail()
        {
            //Cenário
            _mockBookRepository.Setup(rp => rp.Save(_book)).Returns(_book);
            _book = ObjectMother.InvalidBookDateWithoutId();

            //Ação
            Action act = () => _bookService.Add(_book);

            //Verificar
            act.Should().Throw<DefaultPublishDateException>();
            _mockBookRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void BookService_Update_ShouldBeOk()
        {
            //Cenário
            _mockBookRepository.Setup(rp => rp.Update(_book)).Returns(_book);

            //Ação
            Book updatedBook = _bookService.Update(_book);

            //Verificar
            updatedBook.Should().NotBeNull();
            updatedBook.Id.Should().Be(_book.Id);
            _mockBookRepository.Verify(rp => rp.Update(_book));
        }

        [Test]
        public void BookService_UpdateInvalidTitle_ShouldFail()
        {
            //Cenário
            _mockBookRepository.Setup(rp => rp.Update(_book)).Returns(_book);
            _book = ObjectMother.InvalidBookTitleWithoutId();

            //Ação
            Action act = () => _bookService.Update(_book);

            //Verificar
            act.Should().Throw<InvalidTitleLengthException>();
            _mockBookRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void BookService_UpdateInvalidTheme_ShouldFail()
        {
            //Cenário
            _mockBookRepository.Setup(rp => rp.Update(_book)).Returns(_book);
            _book = ObjectMother.InvalidBookThemeWithoutId();

            //Ação
            Action act = () => _bookService.Update(_book);

            //Verificar
            act.Should().Throw<InvalidThemeLengthException>();
            _mockBookRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void BookService_UpdateInvalidAuthor_ShouldFail()
        {
            //Cenário
            _mockBookRepository.Setup(rp => rp.Update(_book)).Returns(_book);
            _book = ObjectMother.InvalidBookAuthorWithoutId();

            //Ação
            Action act = () => _bookService.Update(_book);

            //Verificar
            act.Should().Throw<InvalidAuthorLengthException>();
            _mockBookRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void BookService_UpdateInvalidVolume_ShouldFail()
        {
            //Cenário
            _mockBookRepository.Setup(rp => rp.Update(_book)).Returns(_book);
            _book = ObjectMother.InvalidBookVolumeWithoutId();

            //Ação
            Action act = () => _bookService.Update(_book);

            //Verificar
            act.Should().Throw<InvalidVolumeException>();
            _mockBookRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void BookService_UpdateInvalidDate_ShouldFail()
        {
            //Cenário
            _mockBookRepository.Setup(rp => rp.Update(_book)).Returns(_book);
            _book = ObjectMother.InvalidBookDateWithoutId();

            //Ação
            Action act = () => _bookService.Update(_book);

            //Verificar
            act.Should().Throw<DefaultPublishDateException>();
            _mockBookRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void BookService_Delete_ShouldBeOk()
        {
            //Cenário
            _mockBookRepository.Setup(rp => rp.Delete(_book));

            //Ação
            Action act = () => _bookService.Delete(_book);

            //Verificar
            act.Should().NotThrow<IdentifierUndefinedException>();
            _mockBookRepository.Verify(rp => rp.Delete(_book));
        }

        [Test]
        public void BookService_DeleteInvalidBookId_ShouldFail()
        {
            //Cenário
            _book.Id = _invalidId;
            _mockBookRepository.Setup(rp => rp.Delete(_book));

            //Ação
            Action act = () => _bookService.Delete(_book);

            //Verificar
            act.Should().Throw<IdentifierUndefinedException>();
            _mockBookRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void BookService_Get_ShouldBeOk()
        {
            //Cenário
            _mockBookRepository.Setup(rp => rp.Get(_book.Id)).Returns(_book);

            //Ação
            Book getBook = _bookService.Get(_book);

            //Verificar
            getBook.Id.Should().Be(_book.Id);
            _mockBookRepository.Verify(rp => rp.Get(_book.Id));
        }

        [Test]
        public void BookService_GetInvalidBookId_ShouldFail()
        {
            //Cenário
            _book.Id = _invalidId;
            _mockBookRepository.Setup(rp => rp.Get(_book.Id)).Returns(_book);

            //Ação
            Action act = () => _bookService.Get(_book);

            //Verificar
            act.Should().Throw<IdentifierUndefinedException>();
            _mockBookRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void BookService_GetAll_ShouldBeOk()
        {
            //Cenário
            _mockBookRepository.Setup(rp => rp.GetAll()).Returns(new List<Book>() { _book });

            //Ação
            IEnumerable<Book> booksList = _bookService.GetAll();

            //Verificar
            booksList.First().Id.Should().Be(_book.Id);
            _mockBookRepository.Verify(rp => rp.GetAll());
        }

        [TearDown]
        public void TearDown()
        {
            _book = null;
            _mockBookRepository = null;
            _bookService = null;
        }
    }
}
