using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PollSystem.Application.CQRS.Questions.Queries.GetAllQuestions;
using PollSystem.Application.Interfaces;

namespace PollSystem.Application.CQRS.Comments.Queries.GetComments;

public class GetCommentsCommandHandler : IRequestHandler<GetCommentsCommand, CommentDtoList>
{
    private readonly IPollSystemDbContext _context;
    private readonly IMapper _mapper;

    public GetCommentsCommandHandler(IPollSystemDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<CommentDtoList> Handle(GetCommentsCommand request, CancellationToken cancellationToken)
    {
        var comments = _context.Comments.Where(c => c.Question.Id == request.QuestionId);
        var commentsByQuestion = await comments.OrderByDescending(c => c.CreateTime)
            .Skip((request.CurrentPage - 1) * request.Count)
            .Take(request.Count)
            .ProjectTo<CommentDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        var all = Math.Ceiling((decimal)comments.Count() / request.Count);
        return new CommentDtoList
        {
            Comments = commentsByQuestion,
            Page = new Page
            {
                CurrentPage = request.CurrentPage,
                Count = request.Count,
                Total = (int)all
            }
        };
    }
}