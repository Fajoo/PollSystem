using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PollSystem.Application.Interfaces;

namespace PollSystem.Application.CQRS.Categories.Queries.GetAllCategories;

public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, CategoryListViewModel>
{
    private readonly IPollSystemDbContext _context;
    private readonly IMapper _mapper;

    public GetAllCategoriesQueryHandler(IPollSystemDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<CategoryListViewModel> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
    {
        var query = await _context.Categories
            .ProjectTo<CategoryDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return new CategoryListViewModel() { Categories = query };
    }
}