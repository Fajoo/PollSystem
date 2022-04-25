namespace PollSystem.Domain;

public class Option
{
    /// <summary>
    /// Unique id
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// Option name
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Question
    /// </summary>
    public Question Question { get; set; }
    /// <summary>
    /// List of votes
    /// </summary>
    public List<Vote> Votes { get; set; } = new();
}