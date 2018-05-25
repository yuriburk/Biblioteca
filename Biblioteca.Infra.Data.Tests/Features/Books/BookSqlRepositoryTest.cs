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

namespace Biblioteca.Infra.Data.Tests.Features.Books
{
    [TestFixture]
    public class BookSqlRepositoryTest
    {
        private int _seedId = 1;
        private int _invalidId = 0;

        Book _book;
        IBookRepository _bookRepository;

        [SetUp]
        public void Initialize()
        {
            BaseSqlTest.SeedDataBase();
            _book = ObjectMother.ValidBookWithoutId();
            _bookRepository = new BookSqlRepository();
        }

        [Test]
        public void BaseSqlRepository_Add_ShouldBeOk()
        {
            //Cenário e Ação
            Book savedBook = _bookRepository.Save(_book);

            //Verificar
            savedBook.Id.Should().Be(_book.Id);
        }

        [Test]
        public void BaseSqlRepository_AddInvalidTitle_ShouldFail()
        {
            //Cenário
            _book = ObjectMother.InvalidBookTitleWithoutId();

            //Ação
            Action act = () => _bookRepository.Save(_book);

            //Verificar
            act.Should().Throw<InvalidTitleLengthException>();
        }

        [Test]
        public void BaseSqlRepository_AddInvalidTheme_ShouldFail()
        {
            //Cenário
            _book = ObjectMother.InvalidBookThemeWithoutId();

            //Ação
            Action act = () => _bookRepository.Save(_book);

            //Verificar
            act.Should().Throw<InvalidThemeLengthException>();
        }

        [Test]
        public void BaseSqlRepository_AddInvalidAuthor_ShouldFail()
        {
            //Cenário
            _book = ObjectMother.InvalidBookAuthorWithoutId();

            //Ação
            Action act = () => _bookRepository.Save(_book);

            //Verificar
            act.Should().Throw<InvalidAuthorLengthException>();
        }

        [Test]
        public void BaseSqlRepository_AddInvalidVolume_ShouldFail()
        {
            //Cenário
            _book = ObjectMother.InvalidBookVolumeWithoutId();

            //Ação
            Action act = () => _bookRepository.Save(_book);

            //Verificar
            act.Should().Throw<InvalidVolumeException>();
        }

        [Test]
        public void BaseSqlRepository_AddInvalidDate_ShouldFail()
        {
            //Cenário
            _book = ObjectMother.InvalidBookDateWithoutId();

            //Ação
            Action act = () => _bookRepository.Save(_book);

            //Verificar
            act.Should().Throw<DefaultPublishDateException>();
        }

        [Test]
        public void BaseSqlRepository_Update_ShouldBeOk()
        {
            //Cenário e Ação
            _book.Id = _seedId;
            Book updatedBook = _bookRepository.Update(_book);

            //Verificar
            updatedBook.Id.Should().Be(_book.Id);
        }

        [Test]
        public void BaseSqlRepository_UpdateAvailableToUnavailable_ShouldBeOk()
        {
            //Cenário e Ação
            _bookRepository.Save(_book); //Livro disponível
            _book.Disponibility = false;
            Book updatedBook = _bookRepository.Update(_book);

            //Verificar
            updatedBook.Id.Should().Be(_book.Id);
            updatedBook.Disponibility.Should().Be(false);
        }

        [Test]
        public void BaseSqlRepository_UpdateInvalidTitle_ShouldFail()
        {
            //Cenário
            _book = ObjectMother.InvalidBookTitleWithoutId();
            _book.Id = _seedId;

            //Ação
            Action act = () => _bookRepository.Update(_book);

            //Verificar
            act.Should().Throw<InvalidTitleLengthException>();
        }

        [Test]
        public void BaseSqlRepository_UpdateInvalidTheme_ShouldFail()
        {
            //Cenário
            _book = ObjectMother.InvalidBookThemeWithoutId();
            _book.Id = _seedId;

            //Ação
            Action act = () => _bookRepository.Update(_book);

            //Verificar
            act.Should().Throw<InvalidThemeLengthException>();
        }

        [Test]
        public void BaseSqlRepository_UpdateInvalidAuthor_ShouldFail()
        {
            //Cenário
            _book = ObjectMother.InvalidBookAuthorWithoutId();
            _book.Id = _seedId;

            //Ação
            Action act = () => _bookRepository.Update(_book);

            //Verificar
            act.Should().Throw<InvalidAuthorLengthException>();
        }

        [Test]
        public void BaseSqlRepository_UpdateInvalidVolume_ShouldFail()
        {
            //Cenário
            _book = ObjectMother.InvalidBookVolumeWithoutId();
            _book.Id = _seedId;

            //Ação
            Action act = () => _bookRepository.Update(_book);

            //Verificar
            act.Should().Throw<InvalidVolumeException>();
        }

        [Test]
        public void BaseSqlRepository_UpdateInvalidDate_ShouldFail()
        {
            //Cenário
            _book = ObjectMother.InvalidBookDateWithoutId();
            _book.Id = _seedId;

            //Ação
            Action act = () => _bookRepository.Update(_book);

            //Verificar
            act.Should().Throw<DefaultPublishDateException>();
        }

        [Test]
        public void BaseSqlRepository_Get_ShouldBeOk()
        {
            //Cenário e Ação
            Book getBook = _bookRepository.Get(_seedId);

            //Verificar
            getBook.Id.Should().Be(_seedId);
        }

        [Test]
        public void BaseSqlRepository_GetInvalidId_ShouldFail()
        {
            //Cenário e Ação
            Action act = () => _bookRepository.Get(_invalidId);

            //Verificar
            act.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        public void BaseSqlRepository_Delete_ShouldBeOk()
        {
            //Cenário e Ação
            _book = _bookRepository.Save(_book);
            _bookRepository.Delete(_book);

            //Verificar
            _bookRepository.Get(_book.Id).Should().BeNull();
        }

        [Test]
        public void BaseSqlRepository_DeleteInvalidId_ShouldFail()
        {
            //Cenário e Ação
            _book.Id = _invalidId;
            Action act = () => _bookRepository.Delete(_book);

            //Verificar
            act.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        public void BaseSqlRepository_GetAll_ShouldBeOk()
        {
            //Cenário e Ação
            IEnumerable<Book> booksList = _bookRepository.GetAll();

            //Verificar
            booksList.Should().HaveCount(1);
            booksList.First().Id.Should().Be(_seedId);
        }

        [TearDown]
        public void TearDown()
        {
            _book = null;
            _bookRepository = null;
        }
    }
}
