namespace PollSystem.Domain;

public class Question
{
    /// <summary>
    /// Unique id
    /// </summary>
    public Guid Id  { get; set; }
    /// <summary>
    /// Login of the user who created the poll
    /// </summary>
    public string LoginUser { get; set; }
    /// <summary>
    /// Question name
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Question description
    /// </summary>
    public string? Description { get; set; }
    /// <summary>
    /// Date of creation
    /// </summary>
    public DateTime CreateDate { get; set; }
    /// <summary>
    /// Question settings
    /// </summary>
    public QuestionSettings QuestionSettings { get; set; }
    /// <summary>
    /// Category
    /// </summary>
    public Category Category { get; set; }
    /// <summary>
    /// List of option
    /// </summary>
    public List<Option> Options { get; set; } = new();
    /// <summary>
    /// List of tags
    /// </summary>
    public List<Tag> Tags { get; set; } = new();
    /// <summary>
    /// List of comments
    /// </summary>
    public List<Comment> Comments { get; set; } = new();

}