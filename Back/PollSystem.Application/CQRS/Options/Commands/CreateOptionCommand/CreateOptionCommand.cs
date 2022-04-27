using MediatR;
using PollSystem.Domain;

namespace PollSystem.Application.CQRS.Options.Commands.CreateOptionCommand;

public class CreateOptionCommand : IRequest<Guid>
{
    public string Name { get; set; }

    public Guid QuestionId { get; set; }
}