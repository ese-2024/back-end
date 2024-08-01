using CTFServerSide.Models;
using Microsoft.EntityFrameworkCore;

namespace CTFServerSide.Data
{
    public class CTFContext : DbContext
    {
        public CTFContext(DbContextOptions<CTFContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Challenge> Challenges { get; set; }
        public DbSet<UserChallenge> UserChallenges { get; set; }
        public DbSet<UserQuest> UserQuests { get; set; }
        public DbSet<Quest> Quests { get; set; }
        public DbSet<Step> Steps { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<NecessaryKnowledge> NecessaryKnowledges { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserChallenge>()
                .HasKey(uc => new { uc.UserId, uc.ChallengeId });

            modelBuilder.Entity<UserQuest>()
                .HasKey(uq => new { uq.UserId, uq.QuestId });

            modelBuilder.Entity<UserChallenge>()
                .HasOne(uc => uc.User)
                .WithMany(u => u.UserChallenges)
                .HasForeignKey(uc => uc.UserId);

            modelBuilder.Entity<UserChallenge>()
                .HasOne(uc => uc.Challenge)
                .WithMany(c => c.UserChallenges)
                .HasForeignKey(uc => uc.ChallengeId);

            modelBuilder.Entity<UserQuest>()
                .HasOne(uc => uc.User)
                .WithMany(u => u.UserQuests)
                .HasForeignKey(uc => uc.UserId);

            modelBuilder.Entity<UserQuest>()
                .HasOne(uc => uc.Quest)
                .WithMany(c => c.UserQuests)
                .HasForeignKey(uc => uc.QuestId);

            modelBuilder.Entity<Quest>()
                .HasOne(q => q.Challenge)
                .WithMany(c => c.Quests)
                .HasForeignKey(q => q.ChallengeId);

            modelBuilder.Entity<Step>()
                .HasOne(s => s.Quest)
                .WithMany(q => q.Steps)
                .HasForeignKey(q => q.QuestId);

            modelBuilder.Entity<Material>()
                .HasOne(m => m.Challenge)
                .WithMany(c => c.Materials)
                .HasForeignKey(q => q.ChallengeId);

            modelBuilder.Entity<NecessaryKnowledge>()
                .HasOne(nk => nk.Challenge)
                .WithMany(c => c.NecessaryKnowledges)
                .HasForeignKey(q => q.ChallengeId);

            modelBuilder.Entity<User>()
                .HasIndex(u => u.UserName)
                .IsUnique();

            SeedData.Seed(modelBuilder);
        }
    }
}
