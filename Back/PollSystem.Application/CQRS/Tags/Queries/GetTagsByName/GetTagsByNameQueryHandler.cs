using AutoMapper;
using MediatR;
using PollSystem.Application.Interfaces;

namespace PollSystem.Application.CQRS.Tags.Queries.GetTagsByName;

public class GetTagsByNameQueryHandler : IRequestHandler<GetTagsByNameQuery, IEnumerable<TagDto>>
{
    private readonly IPollSystemDbContext _context;
    private readonly IMapper _mapper;

    public GetTagsByNameQueryHandler(IPollSystemDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<TagDto>> Handle(GetTagsByNameQuery request, CancellationToken cancellationToken)
    {
        var list = _context.Tags
            .Where(t => t.Name.Contains(request.Name))
            .Take(5);
        return _mapper.Map<IEnumerable<TagDto>>(list);
    }
}