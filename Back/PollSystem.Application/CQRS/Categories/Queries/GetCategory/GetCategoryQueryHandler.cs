using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PollSystem.Application.Interfaces;

namespace PollSystem.Application.CQRS.Categories.Queries.GetCategory;

public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery, CategoryDto>
{
    private readonly IPollSystemDbContext _context;
    private readonly IMapper _mapper;

    public GetCategoryQueryHandler(IPollSystemDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<CategoryDto> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
    {
        var entity = await _context.Categories.FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);
        if (entity is null)
            throw new Exception("not found");
        return _mapper.Map<CategoryDto>(entity);
    }
}