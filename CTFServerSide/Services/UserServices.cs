using CTFServerSide.Data;
using CTFServerSide.DTOs;

namespace CTFServerSide.Services
{
    public class UserService
    {
        private readonly CTFContext _context;

        public UserService(CTFContext context)
        {
            _context = context;
        }

        public IEnumerable<UserChallengeDTO> GetUserProgress(int userId)
        {
            return _context
                .UserChallenges.Where(uc => uc.UserId == userId)
                .Select(uc => new UserChallengeDTO
                {
                    ChallengeId = uc.ChallengeId,
                    ChallengeTitle = uc.Challenge.Title,
                    IsCompleted = uc.IsCompleted,
                    CompletedAt = uc.CompletedAt
                })
                .ToList();
        }
    }
}
