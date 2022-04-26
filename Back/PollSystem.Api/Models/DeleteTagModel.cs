using AutoMapper;
using PollSystem.Application.Common.Mappings;
using PollSystem.Application.CQRS.Categories.Commands.CreateCategory;
using PollSystem.Application.CQRS.Tags.Commands.RemoveTag;

namespace PollSystem.Api.Models;

public class DeleteTagModel : IMapWith<RemoveTagCommand>
{
    public Guid Id { get; set; }
    public Guid QuestionId { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<DeleteTagModel, RemoveTagCommand>()
            .ForMember(p => p.Id,
                p => p.MapFrom(p => p.Id))
            .ForMember(p => p.QuestionId,
                p => p.MapFrom(p => p.QuestionId));
    }
}