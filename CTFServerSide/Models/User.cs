namespace CTFServerSide.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int Score { get; set; } = 0;

        public ICollection<UserChallenge> UserChallenges { get; set; }
        public ICollection<UserQuest> UserQuests { get; set; }

    }
}
