namespace PollSystem.Domain;

public class Vote
{
    /// <summary>
    /// Unique id
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// Login of the user who voted in the poll
    /// </summary>
    public string UserLogin { get; set; }
    /// <summary>
    /// Date of vote
    /// </summary>
    public DateTime VoteDate { get; set; }
    /// <summary>
    /// Option
    /// </summary>
    public Option Option { get; set; }
}