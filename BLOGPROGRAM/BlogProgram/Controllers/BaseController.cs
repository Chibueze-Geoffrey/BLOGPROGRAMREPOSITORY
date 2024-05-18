using BlogProgram.Common.DTO.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProgramDirect.Common.Enums;

namespace BlogProgram.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected IActionResult CustomResponse(ApiResponse response)
        {
            switch (response.ResponseCode)
            {
                case ApiResponseCode.Ok: return Ok(response);
                case ApiResponseCode.BadRequest:
                case ApiResponseCode.ProcessingError:
                case ApiResponseCode.Forbidden:
                    return BadRequest(response);
                default: return BadRequest(response);
            }
        }
    }
}
