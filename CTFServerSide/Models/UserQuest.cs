using CTFServerSide.Models;

public class UserQuest
{
    public int UserId { get; set; }
    public User User { get; set; }

    public int QuestId { get; set; }
    public Quest Quest { get; set; }

    public bool IsCompleted { get; set; }
}
