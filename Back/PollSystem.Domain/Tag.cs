namespace PollSystem.Domain;

public class Tag
{
    /// <summary>
    /// Unique id
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// Tag name
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// List of polls
    /// </summary>
    public List<Question> Questions { get; set; } = new();
}