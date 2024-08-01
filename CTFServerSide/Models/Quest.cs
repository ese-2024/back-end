namespace CTFServerSide.Models
{
    public class Quest
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public int Order { get; set; }

        public int ChallengeId { get; set; }
        public Challenge Challenge { get; set; }

        public ICollection<UserQuest> UserQuests { get; set; }
        public ICollection<Step> Steps { get; set; }

    }
}
