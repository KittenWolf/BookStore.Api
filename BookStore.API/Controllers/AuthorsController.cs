using BookStore.API.Requests;
using BookStore.API.Responses;
using BookStore.Core.Abstractions;
using BookStore.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorsService _authorsService;

        public AuthorsController(IAuthorsService authorsService)
        {
            _authorsService = authorsService;
        }

        [HttpGet]
        public async Task<ActionResult<List<AuthorsResponse>>> GetAllAuthors()
        {
            var authors = await _authorsService.GetAllAuthors();
            var response = authors.Select(x => new AuthorsResponse(x.Uid, x.FullName, x.Birthday));

            return Ok(response);
        }

        [HttpGet("{uid:guid}")]
        public async Task<ActionResult<AuthorsResponse>> GetAuthorByUid(Guid uid)
        {
            var author = await _authorsService.GetAuthorByUid(uid);

            if (author == null)
            {
                return NotFound();
            }

            var response = new AuthorsResponse(author.Uid, author.FullName, author.Birthday);

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateAuthor([FromBody] AuthorsRequest request)
        {
            var uid = Guid.NewGuid();
            var (author, error) = Author.Create(uid, request.FullName, request.Birthday);

            if (!string.IsNullOrEmpty(error))
            {
                return BadRequest(error);
            }

            var authorUid = await _authorsService.CreateAuthor(author);

            return Ok(authorUid);
        }

        [HttpPut("{uid:guid}")]
        public async Task<ActionResult<Guid>> UpdateAuthor(Guid uid, [FromBody] AuthorsRequest request)
        {
            var authorUid = await _authorsService.UpdateAuthor(uid, request.FullName, request.Birthday);

            return Ok(authorUid);
        }

        [HttpDelete("{uid:guid}")]
        public async Task<ActionResult<Guid>> DeleteAuthor(Guid uid)
        {
            var authorUid = await _authorsService.DeleteAuthor(uid);

            return Ok(authorUid);
        }
    }
}
