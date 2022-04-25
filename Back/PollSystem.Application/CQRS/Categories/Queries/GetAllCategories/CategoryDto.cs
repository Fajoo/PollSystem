using AutoMapper;
using PollSystem.Application.Common.Mappings;
using PollSystem.Domain;

namespace PollSystem.Application.CQRS.Categories.Queries.GetAllCategories;

public class CategoryDto : IMapWith<Category>
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public string? Img { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Category, CategoryDto>()
            .ForMember(catDto => catDto.Name,
                opt => opt.MapFrom(cat => cat.Name))
            .ForMember(catDto => catDto.Description,
                opt => opt.MapFrom(cat => cat.Description))
            .ForMember(catDto => catDto.Img,
                opt => opt.MapFrom(cat => cat.Img));
    }
}