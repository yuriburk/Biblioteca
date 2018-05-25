using Biblioteca.Applications.Features.Books;
using Biblioteca.Common.Tests.Base;
using Biblioteca.Exceptions;
using Biblioteca.Features.Books;
using Biblioteca.Infra.Data.Features.Books;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Integration.Tests.Features.Books
{
    [TestFixture]
    public class BookIntegrationSqlTest
    {
        int _seedId = 1;
        int _invalidId = 0;

        Book _book;
        BookService _bookService;
        IBookRepository _bookRepository;

        [SetUp]
        public void Initialize()
        {
            BaseSqlTest.SeedDataBase();
            _book = ObjectMother.ValidBookWithoutId();
            _bookRepository = new BookSqlRepository();
            _bookService = new BookService(_bookRepository);
        }

        [Test]
        public void BookIntegrationSql_Add_ShouldBeOk()
        {
            //Cenário e Ação
            Book savedBook = _bookService.Add(_book);

            //Verificar
            savedBook.Should().NotBeNull();
            savedBook.Id.Should().Be(_book.Id);
        }

        [Test]
        public void BookIntegrationSql_AddInvalidTitle_ShouldFail()
        {
            //Cenário
            _book = ObjectMother.InvalidBookTitleWithoutId();

            //Ação
            Action act = () => _bookService.Add(_book);

            //Verificar
            act.Should().Throw<InvalidTitleLengthException>();
        }

        [Test]
        public void BookIntegrationSql_AddInvalidTheme_ShouldFail()
        {
            //Cenário
            _book = ObjectMother.InvalidBookThemeWithoutId();

            //Ação
            Action act = () => _bookService.Add(_book);

            //Verificar
            act.Should().Throw<InvalidThemeLengthException>();
        }

        [Test]
        public void BookIntegrationSql_AddInvalidAuthor_ShouldFail()
        {
            //Cenário
            _book = ObjectMother.InvalidBookAuthorWithoutId();

            //Ação
            Action act = () => _bookService.Add(_book);

            //Verificar
            act.Should().Throw<InvalidAuthorLengthException>();
        }

        [Test]
        public void BookIntegrationSql_AddInvalidVolume_ShouldFail()
        {
            //Cenário
            _book = ObjectMother.InvalidBookVolumeWithoutId();

            //Ação
            Action act = () => _bookService.Add(_book);

            //Verificar
            act.Should().Throw<InvalidVolumeException>();
        }

        [Test]
        public void BookIntegrationSql_AddInvalidDate_ShouldFail()
        {
            //Cenário
            _book = ObjectMother.InvalidBookDateWithoutId();

            //Ação
            Action act = () => _bookService.Add(_book);

            //Verificar
            act.Should().Throw<DefaultPublishDateException>();
        }

        [Test]
        public void BookIntegrationSql_Update_ShouldBeOk()
        {
            //Cenário e Ação
            Book updatedBook = _bookService.Update(_book);

            //Verificar
            updatedBook.Should().NotBeNull();
            updatedBook.Id.Should().Be(_book.Id);
        }

        [Test]
        public void BookIntegrationSql_UpdateInvalidTitle_ShouldFail()
        {
            //Cenário
            _book = ObjectMother.InvalidBookTitleWithoutId();

            //Ação
            Action act = () => _bookService.Update(_book);

            //Verificar
            act.Should().Throw<InvalidTitleLengthException>();
        }

        [Test]
        public void BookIntegrationSql_UpdateInvalidTheme_ShouldFail()
        {
            //Cenário
            _book = ObjectMother.InvalidBookThemeWithoutId();

            //Ação
            Action act = () => _bookService.Update(_book);

            //Verificar
            act.Should().Throw<InvalidThemeLengthException>();
        }

        [Test]
        public void BookIntegrationSql_UpdateInvalidAuthor_ShouldFail()
        {
            //Cenário
            _book = ObjectMother.InvalidBookAuthorWithoutId();

            //Ação
            Action act = () => _bookService.Update(_book);

            //Verificar
            act.Should().Throw<InvalidAuthorLengthException>();
        }

        [Test]
        public void BookIntegrationSql_UpdateInvalidVolume_ShouldFail()
        {
            //Cenário
            _book = ObjectMother.InvalidBookVolumeWithoutId();

            //Ação
            Action act = () => _bookService.Update(_book);

            //Verificar
            act.Should().Throw<InvalidVolumeException>();
        }

        [Test]
        public void BookIntegrationSql_UpdateInvalidDate_ShouldFail()
        {
            //Cenário
            _book = ObjectMother.InvalidBookDateWithoutId();

            //Ação
            Action act = () => _bookService.Update(_book);

            //Verificar
            act.Should().Throw<DefaultPublishDateException>();
        }

        [Test]
        public void BookIntegrationSql_Delete_ShouldBeOk()
        {
            //Cenário e Ação
            _book.Id = _seedId;
            Action act = () => _bookService.Delete(_book);

            //Verificar
            act.Should().NotThrow<IdentifierUndefinedException>();
        }

        [Test]
        public void BookIntegrationSql_DeleteInvalidBookId_ShouldFail()
        {
            //Cenário
            _book.Id = _invalidId;

            //Ação
            Action act = () => _bookService.Delete(_book);

            //Verificar
            act.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        public void BookIntegrationSql_Get_ShouldBeOk()
        {
            //Cenário e Ação
            _book.Id = _seedId;
            Book getBook = _bookService.Get(_book);

            //Verificar
            getBook.Id.Should().Be(_book.Id);
        }

        [Test]
        public void BookIntegrationSql_GetInvalidBookId_ShouldFail()
        {
            //Cenário
            _book.Id = _invalidId;

            //Ação
            Action act = () => _bookService.Get(_book);

            //Verificar
            act.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        public void BookIntegrationSql_GetAll_ShouldBeOk()
        {
            //Cenário e Ação
            IEnumerable<Book> booksList = _bookService.GetAll();

            //Verificar
            booksList.First().Id.Should().Be(_seedId);
        }

        [TearDown]
        public void TearDown()
        {
            _book = null;
            _bookRepository = null;
            _bookService = null;
        }
    }
}
