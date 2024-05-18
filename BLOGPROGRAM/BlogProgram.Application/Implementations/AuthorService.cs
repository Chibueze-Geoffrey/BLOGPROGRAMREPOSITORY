using AutoMapper;
using BlogProgram.Application.Interfaces;
using BlogProgram.Common.DTO.Request;
using BlogProgram.Common.DTO.Response;
using BlogProgram.Common.Helpers;
using BlogProgram.Domain.Entities;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ProgramDirect.Common.Enums;

namespace BlogProgram.Application.Implementations
{
    public class AuthorService : IAuthorService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
       
        private readonly IMemoryCache _cache;
        public AuthorService(IUnitOfWork unitOfWork, IMapper mapper,
             IMemoryCache cache)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
           
            _cache = cache;
        }
        public async Task<ApiResponse> AddAuthorAsync(AuthorRequestDto request)
        {
            try
            {
                var author = _mapper.Map<Author>(request);
                await _unitOfWork.Repository<Author>().AddAsync(author);
                await _unitOfWork.CommitAsync();

                _cache.Remove("authors");

               // _logger.LogInformation($"Successfully added author - {JsonConvert.SerializeObject(author)}");
                return ApiResponse<AuthorResponseDto>
                    .Response(_mapper.Map<AuthorResponseDto>(author), "Successfully created author",ApiResponseCode.Ok);
            }
            catch (Exception ex)
            {
               // _logger.LogError(ex, ex.Message);
                return ApiResponse.Response("Could not add author",ApiResponseCode.BadRequest);
            }
        }

        public ApiResponse<PaginatedResponse<AuthorResponseDto>> GetAllAuthors(int pageSize, int pageNumber)
        {
            var authors = _cache.Get("authors") as List<Author>;

            if (authors == null)
            {
                authors = _unitOfWork.Repository<Author>().GetAll().ToList();
                _cache.Set("authors", authors);
            }

            var paginated = Help.Paginate(authors, ref pageSize, ref pageNumber);
            var paginatedResponse = new PaginatedResponse<AuthorResponseDto>
            {
                PageItems = _mapper.Map<List<AuthorResponseDto>>(paginated),
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalCount = authors.Count()
            };

            return ApiResponse<PaginatedResponse<AuthorResponseDto>>
                .Response(paginatedResponse, "Successfully retrieved authors", ApiResponseCode.Ok);
        }

         ApiResponse<PaginatedResponse<AuthorResponseDto>> IAuthorService.Update(int pageSize, int pageNumber)
        {
            var authors = _cache.Get("authors") as List<Author>;

            var paginated = Help.Paginate(authors, ref pageSize, ref pageNumber);
            var paginatedResponse = new PaginatedResponse<AuthorResponseDto>
            {
                PageItems = _mapper.Map<List<AuthorResponseDto>>(paginated),
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalCount = authors.Count()
            };
            return ApiResponse<PaginatedResponse<AuthorResponseDto>>
                .Response(paginatedResponse, "Successfully updated authors", ApiResponseCode.Ok);
        }
    }
}
