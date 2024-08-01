namespace CTFServerSide.Models
{
    public class NecessaryKnowledge
    {
        public int Id { get; set; }
        public string Knowledge { get; set; }

        public int ChallengeId { get; set; }
        public Challenge Challenge { get; set; }
    }
}
