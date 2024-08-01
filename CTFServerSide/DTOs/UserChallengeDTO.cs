namespace CTFServerSide.DTOs
{
    public class UserChallengeDTO
    {
        public int id {  get; set; }
        public int ChallengeId { get; set; }
        public string ChallengeTitle { get; set;}
        public bool IsCompleted { get; set; }
    }
}
