using CTFServerSide.DTOs;
using CTFServerSide.Services;
using Microsoft.AspNetCore.Mvc;

namespace CTFServerSide.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public IActionResult Register(UserDTO userDto)
        {
            var result = _authService.Register(userDto);
            if (result)
                return Ok("User registered successfully");
            return BadRequest("Registration failed");
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDTO loginDto)
        {
            var token = _authService.Login(loginDto);
            if (token != null)
                return Ok(new { Token = token });
            return Unauthorized("Invalid credentials");
        }
    }
}
