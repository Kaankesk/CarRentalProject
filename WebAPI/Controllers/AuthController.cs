using Business.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public IActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            var userForRegister = _authService.UserExists(userForRegisterDto.Email);
            if (!userForRegister.Success)
            {
                return BadRequest(userForRegister.Message);
            }
            var result = _authService.Register(userForRegisterDto);
            return Ok(_authService.CreateAccessToken(result.Data));

        }


        [HttpPost("login")]
        public IActionResult login(UserForLoginDto userForLoginDto)
        {

            var userToLogin = _authService.Login(userForLoginDto);
            if (!userToLogin.Success)
            {
                return BadRequest(userToLogin.Message);
            };
            var tokenResult = _authService.CreateAccessToken(userToLogin.Data);
            if (!tokenResult.Success)
            {
                return BadRequest(tokenResult.Message);
            }
            return Ok(tokenResult.Data);

        }

    }
}
