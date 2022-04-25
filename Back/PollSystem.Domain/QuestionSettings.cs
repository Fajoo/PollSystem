namespace PollSystem.Domain;

public class QuestionSettings
{
    /// <summary>
    /// Unique id
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// Anonymous voting
    /// </summary>
    public bool IsAnonym { get; set; }
    /// <summary>
    /// Plurality voting
    /// </summary>
    public bool IsMultiple { get; set; }
    /// <summary>
    /// Question
    /// </summary>
    public Question Question { get; set; }
}