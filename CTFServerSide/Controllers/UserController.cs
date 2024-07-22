using CTFServerSide.Services;
using Microsoft.AspNetCore.Mvc;

namespace CTFServerSide.Controllers
{
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
    }
}
