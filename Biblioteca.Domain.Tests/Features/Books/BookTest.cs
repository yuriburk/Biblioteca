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
        public void Book_ValidTitle_ShouldBeOk()
        {
            //Cenário
            _book = ObjectMother.ValidBookWithoutId();

            //Ação
            Action act = () => _book.Validate();

            //Verificar
            act.Should().NotThrow<InvalidTitleLengthException>();
        }

        [Test]
        public void Book_InvalidTitle_ShouldFail()
        {
            //Cenário
            _book = ObjectMother.InvalidBookTitleWithoutId();

            //Ação
            Action act = () => _book.Validate();

            //Verificar
            act.Should().Throw<InvalidTitleLengthException>();
        }

        [Test]
        public void Book_ValidTheme_ShouldBeOk()
        {
            //Cenário
            _book = ObjectMother.ValidBookWithoutId();

            //Ação
            Action act = () => _book.Validate();

            //Verificar
            act.Should().NotThrow<InvalidThemeLengthException>();
        }

        [Test]
        public void Book_InvalidTheme_ShouldFail()
        {
            //Cenário
            _book = ObjectMother.InvalidBookThemeWithoutId();

            //Ação
            Action act = () => _book.Validate();

            //Verificar
            act.Should().Throw<InvalidThemeLengthException>();
        }

        [Test]
        public void Book_ValidAuthor_ShouldBeOk()
        {
            //Cenário
            _book = ObjectMother.ValidBookWithoutId();

            //Ação
            Action act = () => _book.Validate();

            //Verificar
            act.Should().NotThrow<InvalidAuthorLengthException>();
        }

        [Test]
        public void Book_InvalidAuthor_ShouldFail()
        {
            //Cenário
            _book = ObjectMother.InvalidBookAuthorWithoutId();

            //Ação
            Action act = () => _book.Validate();

            //Verificar
            act.Should().Throw<InvalidAuthorLengthException>();
        }

        [Test]
        public void Book_ValidVolume_ShouldBeOk()
        {
            //Cenário
            _book = ObjectMother.ValidBookWithoutId();

            //Ação
            Action act = () => _book.Validate();

            //Verificar
            act.Should().NotThrow<InvalidVolumeException>();
        }

        [Test]
        public void Book_InvalidVolume_ShouldFail()
        {
            //Cenário
            _book = ObjectMother.InvalidBookVolumeWithoutId();

            //Ação
            Action act = () => _book.Validate();

            //Verificar
            act.Should().Throw<InvalidVolumeException>();
        }

        [Test]
        public void Book_ValidPublishDate_ShouldBeOk()
        {
            //Cenário
            _book = ObjectMother.ValidBookWithoutId();

            //Ação
            Action act = () => _book.Validate();

            //Verificar
            act.Should().NotThrow<DefaultPublishDateException>();
        }

        [Test]
        public void Book_InvalidPublishDate_ShouldFail()
        {
            //Cenário
            _book = ObjectMother.InvalidBookDateWithoutId();

            //Ação
            Action act = () => _book.Validate();

            //Verificar
            act.Should().Throw<DefaultPublishDateException>();
        }
    }
}
