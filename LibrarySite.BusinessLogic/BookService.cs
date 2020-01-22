using LibrarySite.BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LibrarySite.BusinessLogic
{
    public class BookService : IBookService
    {
        public void BorrowBook(string bookId, User user)
        {
            var book = GetBookById(bookId);
            if (book.BorrowedBy != null)
            {
                throw new InvalidOperationException("Book was laready borrowed");
            }

            book.BorrowedBy = user;
        }

        public Book GetBookById(string bookId)
        {
            var books = BooksStorage.GetBooks();
            return books.FirstOrDefault(x => x.Id == bookId);
        }

        public List<Book> GetBooks()
        {
            return BooksStorage.GetBooks();
        }
    }
}
