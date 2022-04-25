using AutoMapper;
using PollSystem.Application.Common.Mappings;
using PollSystem.Application.CQRS.Categories.Commands.CreateCategory;

namespace PollSystem.Api.Models;

public class CreateCategoryModel : IMapWith<CreateCategoryCommand>
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public string? Img { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateCategoryModel, CreateCategoryCommand>()
            .ForMember(p => p.Name,
                p => p.MapFrom(p => p.Name))
            .ForMember(p => p.Description,
                p => p.MapFrom(p => p.Description))
            .ForMember(p => p.Img,
                p => p.MapFrom(p => p.Img));
    }
}