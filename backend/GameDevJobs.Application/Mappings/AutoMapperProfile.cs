using AutoMapper;
using Backend.Application.Dto.Categories;
using Backend.Application.Dto.Companies;
using Backend.Application.Dto.Locations;
using Backend.Application.Dto.Offers;
using Backend.Application.Dto.Seniorities;
using Backend.Application.Dto.WorkingTimes;
using Backend.Domain.Entities;

namespace Backend.Application.Mappings;
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

        CreateMap<Offer, OfferDto>();
        CreateMap<OfferDto, Offer>();
    }
}
