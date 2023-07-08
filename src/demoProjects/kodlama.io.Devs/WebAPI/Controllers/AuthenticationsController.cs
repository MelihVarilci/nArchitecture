using Application.Features.Authentications.Commands.Login;
using Application.Features.Authentications.Commands.Register;
using Application.Features.Authentications.Dtos;
using Core.Security.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationsController : BaseController
    {
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] UserForLoginDto userForLoginDto)
        {
            LoggedResponse response = await Mediator.Send(new LoginCommand
            {
                UserForLoginDto = userForLoginDto,
                IpAddress = getIpAddress()
            });

            if (response.RefreshToken is not null) setRefreshTokenToCookie(response.RefreshToken);

            return Ok(response.ToHttpResponse());
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] UserForRegisterDto userForRegisterDto)
        {
            RegisteredResponse result = await Mediator.Send(new RegisterCommand
            {
                UserForRegisterDto = userForRegisterDto,
                IpAddress = getIpAddress()
            });

            setRefreshTokenToCookie(result.RefreshToken);

            return Ok(result.AccessToken);
        }
    }
}