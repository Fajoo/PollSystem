using AutoMapper;
using PollSystem.Application.Common.Mappings;
using PollSystem.Domain;

namespace PollSystem.Application.CQRS.Tags.Queries.GetTagsByName;

public class TagDto : IMapWith<Tag>
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<TagDto, Tag>()
            .ForMember(p => p.Id,
                p => p.MapFrom(p => p.Id))
            .ForMember(p => p.Name,
                p => p.MapFrom(p => p.Name));
    }
}