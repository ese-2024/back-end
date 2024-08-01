using CTFServerSide.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CTFServerSide.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class RankingController : ControllerBase
    {
        private readonly RankingService _rankingService;

        public RankingController(RankingService rankingService)
        {
            _rankingService = rankingService;
        }

        [HttpGet]
        public IActionResult GetRanking()
        {
            var ranking = _rankingService.GetRanking();
            var result = ranking.Select(u => new
            {
                Position = ranking.IndexOf(u) + 1,
                Name = u.UserName,
                Score = u.Score,
                CompletedChallenges = u.UserChallenges.Count(uc => uc.IsCompleted)
            });

            return Ok(result);
        }
    }
}
