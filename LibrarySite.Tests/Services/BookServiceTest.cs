using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibrarySite.BusinessLogic;
using LibrarySite.BusinessLogic.Models;

namespace LibrarySite.Tests.Services
{
    [TestClass]
    public class BookServiceTest
    {
        [TestMethod]
        public void GetBooks()
        {
            // Arrange
            BookService service = new BookService();

            // Act
            var result = service.GetBooks();

            // Assert
            Assert.IsTrue(result.Any());
        }

        [TestMethod]
        public void GetBookById()
        {
            // Arrange
            BookService service = new BookService();

            // Act
            var allBooks = service.GetBooks();
            var firstBook = allBooks.First();

            // Assert
            Assert.IsTrue(service.GetBookById(firstBook.Id) == firstBook);
        }

        [TestMethod]
        public void BorrowABook()
        {
            // Arrange
            BookService service = new BookService();

            // Act
            var allBooks = service.GetBooks();
            var firstBook = allBooks.First();

            var user = new User() {  FullName = "Test User"};

            Assert.IsNull(firstBook.BorrowedBy);

            service.BorrowBook(firstBook.Id, user);

            // Assert
            Assert.IsTrue(firstBook.BorrowedBy == user);
            Assert.IsNotNull(firstBook.BorrowedBy);
        }
    }
}
