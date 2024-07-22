using Microsoft.EntityFrameworkCore;

namespace CTFServerSide.Data
{    public class CTFContext : DbContext
    {
        public CTFContext(DbContextOptions<CTFContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Challenge> Challenges { get; set; }
        public DbSet<UserChallenge> UserChallenges { get; set; }
    }
}
