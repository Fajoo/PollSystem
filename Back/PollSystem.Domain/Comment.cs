namespace PollSystem.Domain;

public class Comment
{
    public Guid Id { get; set; }
    public string UserLogin { get; set; }
    public string Text { get; set; }
    public DateTime CreateTime{ get; set; }
    public Question Question { get; set; }
}