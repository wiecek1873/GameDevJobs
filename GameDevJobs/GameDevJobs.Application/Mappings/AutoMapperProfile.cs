using AutoMapper;
using GameDevJobs.Application.Dto.Categories;
using GameDevJobs.Domain.Entities;

namespace GameDevJobs.Application.Mappings;
public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Category, CategoryDto>();
        CreateMap<CategoryDto, Category>();
        CreateMap<RequestCategoryDto, Category>();
    }
}
