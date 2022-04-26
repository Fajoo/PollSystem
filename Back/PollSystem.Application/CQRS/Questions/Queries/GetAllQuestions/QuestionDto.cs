using AutoMapper;
using PollSystem.Application.Common.Mappings;
using PollSystem.Application.CQRS.Categories.Queries.GetAllCategories;
using PollSystem.Domain;

namespace PollSystem.Application.CQRS.Questions.Queries.GetAllQuestions;

public class QuestionDto : IMapWith<Question>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatDate { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Question, QuestionDto>()
            .ForMember(q => q.Name,
                q => q.MapFrom(q => q.Name))
            .ForMember(q => q.Id,
                q => q.MapFrom(q => q.Id))
            .ForMember(q => q.CreatDate,
                q => q.MapFrom(q => q.CreatDate));
    }
}