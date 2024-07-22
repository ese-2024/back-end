using System.Security.Claims;
using CTFServerSide.Data;
using CTFServerSide.DTOs;
using CTFServerSide.Models;

namespace CTFServerSide.Services
{
    public class ChallengeService
    {
        private readonly CTFContext _context;

        public ChallengeService(CTFContext context)
        {
            _context = context;
        }

        public IEnumerable<ChallengeDTO> GetChallenges()
        {
            return _context
                .Challenges.Select(c => new ChallengeDTO
                {
                    Id = c.Id,
                    Title = c.Title,
                    Description = c.Description
                })
                .ToList();
        }

        public bool CheckAnswer(int challengeId, string answer)
        {
            var challenge = _context.Challenges.Find(challengeId);
            if (challenge == null)
            {
                return false;
            }

            var isCorrect = challenge.CorrectAnswer.Equals(
                answer,
                StringComparison.OrdinalIgnoreCase
            );
            if (isCorrect)
            {
                var userId = int.Parse(ClaimsPrincipal.Current.Identity.Name); // Assuming the user ID is stored in the JWT claims
                var userChallenge = _context.UserChallenges.SingleOrDefault(uc =>
                    uc.UserId == userId && uc.ChallengeId == challengeId
                );
                if (userChallenge == null)
                {
                    userChallenge = new UserChallenge
                    {
                        UserId = userId,
                        ChallengeId = challengeId,
                        IsCompleted = true,
                        CompletedAt = DateTime.UtcNow
                    };
                    _context.UserChallenges.Add(userChallenge);
                }
                else
                {
                    userChallenge.IsCompleted = true;
                    userChallenge.CompletedAt = DateTime.UtcNow;
                    _context.UserChallenges.Update(userChallenge);
                }
                _context.SaveChanges();
            }

            return isCorrect;
        }
    }
}
