using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_books.Data.Services;
using my_books.Data.ViewModels;

namespace my_books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private AuthorsService _authorsService;

        public AuthorController(AuthorsService authorsService)
        {
            _authorsService = authorsService;
        }

        [HttpPost("add-author")]
        public IActionResult AddAuthor([FromBody]AuthorVM authorVM)
        {
            _authorsService.AddAuthor(authorVM);
            return Ok();

        }

        [HttpGet("get-author-with-book-title/{authorId}")]
        public IActionResult GetAuthorWithBookTitle(int authorId)
        {
            var response = _authorsService.GetAuthorWithBookNames(authorId);
            return Ok(response);
        }
    }
}
