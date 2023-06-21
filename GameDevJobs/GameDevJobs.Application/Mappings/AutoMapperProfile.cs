using AutoMapper;
using GameDevJobs.Application.Dto.Categories;
using GameDevJobs.Application.Dto.Companies;
using GameDevJobs.Application.Dto.Locations;
using GameDevJobs.Application.Dto.Seniorities;
using GameDevJobs.Application.Dto.WorkingTimes;
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

        CreateMap<Seniority, SeniorityDto>();
        CreateMap<SeniorityDto, Seniority>();
        CreateMap<RequestSeniorityDto, Seniority>();

        CreateMap<WorkingTime, WorkingTimeDto>();
        CreateMap<WorkingTimeDto, WorkingTime>();
        CreateMap<RequestWorkingTimeDto, WorkingTime>();

        CreateMap<Company, CompanyDto>();
        CreateMap<CompanyDto, Company>();
        CreateMap<RequestCompanyDto, Company>();
    }
}
