using CTFServerSide.Data;
using CTFServerSide.Models;
using Microsoft.EntityFrameworkCore;

namespace CTFServerSide.Services
{
    public class RankingService
    {
        private readonly CTFContext _context;

        public RankingService(CTFContext context)
        {
            _context = context;
        }

        public List<User> GetRanking()
        {
            var users = _context.Users
                .Include(u => u.UserChallenges) 
                .AsEnumerable() 
                .Select(u => new
                {
                    User = u,
                    CompletedChallengesCount = u.UserChallenges.Count(uc => uc.IsCompleted)
                })
                .OrderByDescending(u => u.User.Score)
                .ThenByDescending(u => u.CompletedChallengesCount)
                .Select(u => u.User)
                .ToList();

            return users;
        }
    }
}
