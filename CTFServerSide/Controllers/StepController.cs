using CTFServerSide.DTOs;
using CTFServerSide.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CTFServerSide.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class StepController : ControllerBase
    {
        private readonly StepService _stepService;

        public StepController(StepService stepService)
        {
            _stepService = stepService;
        }

        [HttpPost("submit")]
        public IActionResult SubmitStepAnswer([FromBody] StepSubmissionDTO stepSubmission)
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.Name));
            var result = _stepService.SubmitStepAnswer(stepSubmission, userId);

            if (result)
            {
                return Ok(new { Message = "Answer is correct and step is completed." });
            }
            else
            {
                return BadRequest(new { Message = "Answer is incorrect or step not found." });
            }
        }
    }
}