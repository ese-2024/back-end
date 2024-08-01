namespace CTFServerSide.Models
{
    public class Step
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string ExpectedAnswer { get; set; }
        public string Command { get; set; }
        public bool IsCompleted { get; set; }
        public int Order { get; set; }


        public int QuestId { get; set; }
        public Quest Quest { get; set; }
    }
}
