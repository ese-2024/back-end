using CTFServerSide.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CTFServerSide.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService;

        public UsersController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id}/progress")]
        public IActionResult GetUserProgress(int id)
        {
            var progress = _userService.GetUserProgress(id);
            return Ok(progress);
        }

        [HttpGet("me")]
        public IActionResult GetCurrentUser()
        {
            var userId = User.FindFirst(ClaimTypes.Name)?.Value;

            if (userId == null)
            {
                return Unauthorized();
            }

            var user = _userService.GetCurrentUser(int.Parse(userId));

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }
    }
}
