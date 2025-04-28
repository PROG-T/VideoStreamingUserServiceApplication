using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using VideoStreamingUserServiceApplication.Applications.Features.Registration;
using VideoStreamingUserServiceApplication.Domain.ViewModels;

namespace VideoStreamingUserServiceApplication.Api.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediatr;
        public UserController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }


        [HttpPost("register")]
        [ProducesResponseType(typeof(BaseResponse<string>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BaseResponse<string>), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Register([FromBody] RegisterUserRequest request)
        {
            var command = new RegisterUserCommand
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Password = request.Password
            };

            var response = await _mediatr.Send(command);
            return response.Status ? Ok(response) : BadRequest(response);
        }


        [HttpPost("login")]
        [ProducesResponseType(typeof(BaseResponse<string>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BaseResponse<string>), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Login([FromBody] LoginUserRequest request)
        {
            var command = new LoginUserCommand
            {
                Email = request.Email,
                Password = request.Password
            };
            var response = await _mediatr.Send(command);
            return response.Status ? Ok(response) : BadRequest(response);
        }
    }
}
