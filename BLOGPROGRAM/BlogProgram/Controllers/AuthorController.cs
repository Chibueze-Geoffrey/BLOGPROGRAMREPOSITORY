using BlogProgram.Application.Interfaces;
using BlogProgram.Common.DTO.Request;
using BlogProgram.Common.DTO.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogProgram.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : BaseController
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ApiResponse), 200)]
        [ProducesResponseType(typeof(ApiResponse), 400)]
        public async Task<IActionResult> AddAuthor(AuthorRequestDto request)
        {
            return CustomResponse(await _authorService.AddAuthorAsync(request));
        }

        [HttpPut("author")]
        [ProducesResponseType(typeof(ApiResponse), 200)]
        [ProducesResponseType(typeof(ApiResponse), 400)]
        public IActionResult UpdateAuthor(int pageSize, int pageNumber, [FromBody] AuthorRequestDto request)
        {
            return CustomResponse(_authorService.Update(pageSize, pageNumber));
        }

        [HttpGet("authors/{authorId}")]
        [ProducesResponseType(typeof(ApiResponse<List<AuthorResponseDto>>), 200)]
        [ProducesResponseType(typeof(ApiResponse), 400)]
        public IActionResult GetAuthors(int pageSize, int pageNumber)
        {
            return CustomResponse(_authorService.GetAllAuthors(pageSize, pageNumber));
        }
    }
}
