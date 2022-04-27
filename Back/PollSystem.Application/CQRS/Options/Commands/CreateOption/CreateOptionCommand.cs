using MediatR;

namespace PollSystem.Application.CQRS.Options.Commands.CreateOption;

public class CreateOptionCommand : IRequest<Guid>
{
    public string Name { get; set; }

    public Guid QuestionId { get; set; }
}