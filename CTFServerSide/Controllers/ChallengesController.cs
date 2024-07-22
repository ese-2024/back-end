using CTFServerSide.Services;
using Microsoft.AspNetCore.Mvc;

namespace CTFServerSide.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChallengesController : ControllerBase
    {
        private readonly ChallengeService _challengeService;

        public ChallengesController(ChallengeService challengeService)
        {
            _challengeService = challengeService;
        }

        [HttpGet]
        public IActionResult GetChallenges()
        {
            var challenges = _challengeService.GetChallenges();
            return Ok(challenges);
        }

        [HttpPost("{id}/submit")]
        public IActionResult SubmitAnswer(int id, [FromBody] string answer)
        {
            var result = _challengeService.CheckAnswer(id, answer);
            if (result)
                return Ok("Correct answer!");
            return BadRequest("Incorrect answer");
        }
    }
}
