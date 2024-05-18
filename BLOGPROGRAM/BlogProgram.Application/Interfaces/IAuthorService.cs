using BlogProgram.Common.DTO.Request;
using BlogProgram.Common.DTO.Response;

namespace BlogProgram.Application.Interfaces
{
    public interface IAuthorService
    {
        Task<ApiResponse> AddAuthorAsync(AuthorRequestDto request);
         ApiResponse<PaginatedResponse<AuthorResponseDto>> GetAllAuthors(int pageSize, int pageNumber);
        ApiResponse<PaginatedResponse<AuthorResponseDto>> Update(int pageSize, int pageNumber);
    }
}
