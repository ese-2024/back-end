namespace CTFServerSide.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; } // In a real application, you would store a hashed password
        public string Email { get; set; }

        public ICollection<UserChallenge> UserChallenges { get; set; }
    }
}
