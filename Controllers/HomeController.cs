using LibrarySite.BusinessLogic;
using System;
using System.Web.Mvc;

namespace LibrarySite.Controllers
{
    public class HomeController : Controller
    {
        private IBookService _bookService;

        private IUserService _userService;

        public HomeController(IBookService bookService, IUserService userService)
        {
            if (bookService == null)
                throw new ArgumentNullException(nameof(bookService));

            if (userService == null)
                throw new ArgumentNullException(nameof(userService));

            _bookService = bookService;
            _userService = userService;
        }

        public ActionResult Index()
        {
            return View(_bookService.GetBooks());
        }

        public ActionResult Details(string id)
        {
            return View(nameof(Details),_bookService.GetBookById(id));
        }

        [HttpPost]
        public ActionResult BorrowBook(string username, string bookId)
        {
            if (string.IsNullOrEmpty(username))
            {
                ModelState.AddModelError(nameof(username), "User can't be empty");
            }
            else
            {
                var user = _userService.GetOrCreate(username);
                _bookService.BorrowBook(bookId, user);
            }

            return View(nameof(Details), _bookService.GetBookById(bookId));
        }
    }
}