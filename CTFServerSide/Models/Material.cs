namespace CTFServerSide.Models
{
    public class Material
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }

        public int ChallengeId { get; set; }
        public Challenge Challenge { get; set; }

    }
}
