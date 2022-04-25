using MediatR;
using Microsoft.EntityFrameworkCore;
using PollSystem.Application.Interfaces;
using PollSystem.Domain;

namespace PollSystem.Application.CQRS.Categories.Commands.CreateCategory;

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Guid>
{
    private readonly IPollSystemDbContext _context;

    public CreateCategoryCommandHandler(IPollSystemDbContext context)
    {
        _context = context;
    }
    public async Task<Guid> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var model = request;
        if (await _context.Categories.FirstOrDefaultAsync(c => c.Name == model.Name, cancellationToken: cancellationToken) is not null)
            throw new Exception("Category name already exists");
        var newCat = new Category
        {
            Id = Guid.NewGuid(),
            Name = model.Name,
            Description = model.Description,
            Img = model.Img
        };
        await _context.Categories.AddAsync(newCat, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return newCat.Id;
    }
}