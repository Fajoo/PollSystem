namespace PollSystem.Domain;

public class Category
{
    /// <summary>
    /// Unique id
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// Category name
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Category description
    /// </summary>
    public string? Description { get; set; }
    /// <summary>
    /// Link to picture
    /// </summary>
    public string? Img { get; set; }
    /// <summary>
    /// List of polls
    /// </summary>
    public List<Question> Questions { get; set; } = new();
}