using MediatR;

namespace PollSystem.Application.CQRS.Tags.Queries.GetTagsByName;

public class GetTagsByNameQuery : IRequest<IEnumerable<TagDto>>
{
    public string Name { get; set; }
}