using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PollSystem.Application.Interfaces;

namespace PollSystem.Application.CQRS.Questions.Queries.GetAllQuestions;

public class GetAllQuestionsQueryHandler : IRequestHandler<GetAllQuestionsQuery, QuestionDtoList>
{
    private readonly IPollSystemDbContext _context;
    private readonly IMapper _mapper;

    public GetAllQuestionsQueryHandler(IPollSystemDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<QuestionDtoList> Handle(GetAllQuestionsQuery request, CancellationToken cancellationToken)
    {
        var res = await _context.Questions
            .OrderBy(q => q.Name)
            .Skip((request.CurrentPage - 1) * request.Count)
            .Take(request.Count)
            .ProjectTo<QuestionDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        var all = Math.Ceiling((decimal)_context.Questions.Count() / request.Count);
        return new QuestionDtoList
        {
            Questions = res,
            Page = new Page
            {
                CurrentPage = request.CurrentPage,
                Count = request.Count,
                Total = (int)all
            }
        };
    }
}