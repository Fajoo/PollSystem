using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PollSystem.Application.Interfaces;

namespace PollSystem.Application.CQRS.Questions.Queries.GetQuestion;

public class GetQuestionQueryHandler : IRequestHandler<GetQuestionQuery, QuestionDto>
{
    private readonly IPollSystemDbContext _context;
    private readonly IMapper _mapper;

    public GetQuestionQueryHandler(IPollSystemDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<QuestionDto> Handle(GetQuestionQuery request, CancellationToken cancellationToken)
    {
        var question = await _context.Questions
            .Include(q => q.Options)
            .ThenInclude(v => v.Votes)
            .FirstOrDefaultAsync(q => q.Id == request.QuestionId, cancellationToken)
            .ConfigureAwait(false);
        if (question is null)
            throw new Exception("not found");

        var options = question.Options
            .OrderByDescending(o => o.Votes.Count);

        return new QuestionDto
        {
            Id = question.Id,
            Name = question.Name,
            Description = question.Description,
            LoginUser = question.LoginUser,
            CreateDate = DateTime.Now,
            Options = _mapper.Map<IEnumerable<OptionDto>>(options)
        };
    }
}