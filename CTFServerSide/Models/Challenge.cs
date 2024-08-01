namespace CTFServerSide.Models
{
    public class Challenge
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Level { get; set; }

        public ICollection<NecessaryKnowledge> NecessaryKnowledges { get; set; }
        public ICollection<Material> Materials { get; set; }
        public ICollection<UserChallenge> UserChallenges { get; set; }
        public ICollection<Quest> Quests { get; set; }

    }
}
