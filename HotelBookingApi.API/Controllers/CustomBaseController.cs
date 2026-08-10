using HotelBookingApi.Core.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingApi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomBaseController : ControllerBase
    {
        [NonAction]
        public IActionResult CreateActionResult<T>(CustomResponseDto<T> response)
        {
            if (response.StatusCode == 204)
            {
                return new NoContentResult(); // Standard 204 No Content
            }

            return new ObjectResult(response) { StatusCode = response.StatusCode };
        }
    }
}
