using Biblioteca.Exceptions;
using Biblioteca.Features.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Applications.Features.Books
{
    public class BookService : IBookService
    {
        private IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public Book Add(Book book)
        {
            book.Validate();
            return _bookRepository.Save(book);
        }

        public void Delete(Book book)
        {
            if (book.Id == 0)
                throw new IdentifierUndefinedException();

            _bookRepository.Delete(book);
        }

        public Book Get(Book book)
        {
            if (book.Id == 0)
                throw new IdentifierUndefinedException();

            return _bookRepository.Get(book.Id);
        }

        public IEnumerable<Book> GetAll()
        {
            return _bookRepository.GetAll();
        }

        public Book Update(Book book)
        {
            book.Validate();
            return _bookRepository.Update(book);
        }
    }
}
