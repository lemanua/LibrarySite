using LibrarySite.BusinessLogic.Models;
using System.Collections.Generic;

namespace LibrarySite.BusinessLogic
{
    public interface IBookService
    {
        List<Book> GetBooks();

        Book GetBookById(string bookId);

        void BorrowBook(string bookId, User user);
    }
}
