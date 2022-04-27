using AutoMapper;
using PollSystem.Application.Common.Mappings;
using PollSystem.Application.CQRS.Questions.Commands.CreateQuestion;
using PollSystem.Application.CQRS.Questions.Queries.GetAllQuestions;
using PollSystem.Domain;

namespace PollSystem.Api.Models;

public class CreateQuestionModel : IMapWith<CreateQuestionCommand>
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public Guid CategoryId { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateQuestionModel, CreateQuestionCommand>()
            .ForMember(q => q.Name,
                q => q.MapFrom(q => q.Name))
            .ForMember(q => q.CategoryId,
                q => q.MapFrom(q => q.CategoryId))
            .ForMember(q => q.Description,
                q => q.MapFrom(q => q.Description));
    }
}