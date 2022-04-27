using AutoMapper;
using PollSystem.Application.Common.Mappings;
using PollSystem.Application.CQRS.Comments.Commands.CreateComment;
using PollSystem.Application.CQRS.Questions.Commands.CreateQuestion;

namespace PollSystem.Api.Models;

public class CreateCommentModel : IMapWith<CreateCommentCommand>
{
    public string Text { get; set; }
    public Guid QuestionId { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateCommentModel, CreateCommentCommand>()
            .ForMember(q => q.QuestionId,
                q => q.MapFrom(q => q.QuestionId))
            .ForMember(q => q.Text,
                q => q.MapFrom(q => q.Text));
    }
}