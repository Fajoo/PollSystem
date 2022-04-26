using PollSystem.Domain;

namespace PollSystem.Api.Models;

public class CreateQuestionModel
{
    public string LoginUser { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public Guid CategoryId { get; set; }
}