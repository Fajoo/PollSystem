using AutoMapper;
using PollSystem.Application.Common.Mappings;
using PollSystem.Domain;

namespace PollSystem.Application.CQRS.Questions.Queries.GetQuestion;

public class OptionDto : IMapWith<Option>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int CountVote { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Option, OptionDto>()
            .ForMember(o => o.Name,
                o => o.MapFrom(o => o.Name))
            .ForMember(o => o.Id,
                o => o.MapFrom(o => o.Id))
            .ForMember(o => o.CountVote,
                o => o.MapFrom(o => o.Votes.Count));
    }
}