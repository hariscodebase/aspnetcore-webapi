using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_books.Data.Services;
using my_books.Data.ViewModels;

namespace my_books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class BooksController : ControllerBase
    {
        private BooksService _booksService;

        public BooksController(BooksService booksService)
        {
            _booksService = booksService;
        }

        //Add a new book
        [HttpPost("add-book")]
        public IActionResult AddBook([FromBody]BookVM book)
        {
            _booksService.AddBook(book);
            return Ok();
        }


        //Add a new book
        [HttpPost("add-book-with-authors")]
        public IActionResult AddBookWithAuthors([FromBody]BookVM book)
        {
            _booksService.AddBookWithAuthors(book);
            return Ok();
        }

        //Get all books
        [HttpGet("get-all-books")]
        public IActionResult GetAllBooks()
        {
            var allBooks = _booksService.GetBooks();
            return Ok(allBooks);

        }

        //Get book by id
        [HttpGet("get-book-by-id/{id}")]
        public IActionResult GetBookById(int id)
        {
            var book = _booksService.GetBookById(id);
            return Ok(book);
        }

        //Update book
        [HttpPut("update-book-by-id/{id}")]
        public IActionResult UpdateBookById(int id, [FromBody]BookVM book)
        {
            _booksService.UpdateBookById(id, book);
            return Ok();
        }

        [HttpDelete("delete-book-by-id/{id}")]
        public IActionResult DeleteBookById(int id)
        {
            _booksService.DeleteBookById(id);
            return Ok();
        }
    }
}
