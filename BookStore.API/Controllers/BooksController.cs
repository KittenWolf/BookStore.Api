using BookStore.API.Requests;
using BookStore.API.Responses;
using BookStore.Core.Abstractions;
using BookStore.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBooksService _booksService;

        public BooksController(IBooksService booksService)
        {
            _booksService = booksService;
        }

        [HttpGet]
        public async Task<ActionResult<List<BooksResponse>>> GetAllBooks()
        {
            var books = await _booksService.GetAllBooks();
            var response = books.Select(x => new BooksResponse(x.Title, x.Uid, x.PublishedYear, x.Genre, x.AuthorUid));

            return Ok(response);
        }

        [HttpGet("{uid:guid}")]
        public async Task<ActionResult<BooksResponse>> GetBookByUid(Guid uid)
        {
            var book = await _booksService.GetBookByUid(uid);

            if (book == null)
            {
                return NotFound();
            }

            var response = new BooksResponse(book.Title, book.Uid, book.PublishedYear, book.Genre, book.AuthorUid);

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateBook([FromBody] BooksRequest request)
        {
            var uid = Guid.NewGuid();
            var (book, error) = Book.Create(uid, request.Title, request.PublishedYear, request.Genre, request.AuthorUid);

            if (!string.IsNullOrEmpty(error))
            {
                return BadRequest(error);
            }

            var bookUid = await _booksService.CreateBook(book);

            return Ok(bookUid);
        }

        [HttpPut("{uid:guid}")]
        public async Task<ActionResult<Guid>> UpdateBook(Guid uid, [FromBody] BooksRequest request)
        {
            var bookUid = await _booksService.UpdateBook(uid, request.Title, request.PublishedYear, request.Genre, request.AuthorUid);

            return Ok(bookUid);
        }

        [HttpDelete("{uid:guid}")]
        public async Task<ActionResult<Guid>> DeleteBook(Guid uid)
        {
            var bookUid = await _booksService.DeleteBook(uid);

            return Ok(bookUid);
        }
    }
}
