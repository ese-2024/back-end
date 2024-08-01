using CTFServerSide.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CTFServerSide.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UserProgressController : ControllerBase
    {
        private readonly UserProgressService _userProgressService;

        public UserProgressController(UserProgressService userProgressService)
        {
            _userProgressService = userProgressService;
        }

        [HttpGet("challenges/completed")]
        public ActionResult<IEnumerable<ChallengeDTO>> GetCompletedChallenges()
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.Name)); // Assumes user ID is stored in JWT claims
            var completedChallenges = _userProgressService.GetCompletedChallenges(userId);
            return Ok(completedChallenges);
        }

        [HttpGet("quests/completed")]
        public ActionResult<IEnumerable<QuestDTO>> GetCompletedQuests()
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.Name)); // Assumes user ID is stored in JWT claims
            var completedQuests = _userProgressService.GetCompletedQuests(userId);
            return Ok(completedQuests);
        }
    }
}
