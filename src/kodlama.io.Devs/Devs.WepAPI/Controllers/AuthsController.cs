using Core.Security.Dtos;
using Core.Security.Entities;
using Devs.Application.Features.Users.Commands.LoginCommand;
using Devs.Application.Features.Users.Commands.RegisterCommand;
using Devs.Application.Features.Users.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Devs.WepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthsController : BaseController
    {
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserForLoginDto UserForLoginDto)
        {
            LoginUserCommand LoginCommand = new()
            {
                UserForLoginDto = UserForLoginDto,
                IpAddress = GetIpAddress()
            };

            LoginedUserDto result = await Mediator.Send(LoginCommand);
            SetRefreshTokenToCookie(result.RefreshToken);
            return Created("", result.AccessToken);
        }

        private void SetRefreshTokenToCookie(RefreshToken refreshToken)
        {
            CookieOptions cookieOptions = new() { HttpOnly = true, Expires = DateTime.Now.AddDays(7) };
            Response.Cookies.Append("refreshToken", refreshToken.Token, cookieOptions);
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserForRegisterDto UserForRegisterDto)
        {
            RegisterUserCommand registerCommand = new()
            {
                UserForRegisterDto = UserForRegisterDto,
                IpAddress = GetIpAddress()
            };

            RegisteredUserDto result = await Mediator.Send(registerCommand);
            SetRefreshTokenToCookie(result.RefreshToken);
            return Created("", result.AccessToken);
        }

    }
}
