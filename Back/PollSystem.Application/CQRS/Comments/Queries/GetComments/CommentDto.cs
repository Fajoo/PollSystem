using AutoMapper;
using PollSystem.Application.Common.Mappings;
using PollSystem.Application.CQRS.Questions.Queries.GetAllQuestions;
using PollSystem.Domain;

namespace PollSystem.Application.CQRS.Comments.Queries.GetComments;

public class CommentDto : IMapWith<Comment>
{
    public Guid Id { get; set; }
    public string UserLogin { get; set; }
    public string Text { get; set; }
    public DateTime CreateTime { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Comment, CommentDto>()
            .ForMember(q => q.Text,
                q => q.MapFrom(q => q.Text))
            .ForMember(q => q.Id,
                q => q.MapFrom(q => q.Id))
            .ForMember(q => q.CreateTime,
                q => q.MapFrom(q => q.CreateTime))
            .ForMember(q => q.UserLogin,
                q => q.MapFrom(q => q.UserLogin));
    }
}