using AutoMapper;
using GameDevJobs.Application.Dto.Categories;
using GameDevJobs.Application.Dto.Locations;
using GameDevJobs.Domain.Entities;

namespace GameDevJobs.Application.Mappings;
public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Category, CategoryDto>();
        CreateMap<CategoryDto, Category>();
        CreateMap<RequestCategoryDto, Category>();

        CreateMap<Location, LocationDto>();
        CreateMap<LocationDto, Location>();
        CreateMap<RequestLocationDto, Location>();
    }
}
