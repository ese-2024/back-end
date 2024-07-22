public class Challenge
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Command { get; set; }
    public string CorrectAnswer { get; set; }

    public ICollection<UserChallenge> UserChallenges { get; set; }
}
