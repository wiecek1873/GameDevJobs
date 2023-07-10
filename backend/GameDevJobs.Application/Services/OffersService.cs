using AutoMapper;
using Backend.Application.Dto.Offers;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Entities;
using Backend.Domain.Interfaces;
using GameDevJobs.Application.Exceptions;
using GameDevJobs.Domain.Entities;

namespace Backend.Application.Services;
public class OffersService : IOffersService
{
    private const string NOT_FOUND_MESSAGE = "Offer with this id does not exist.";

    private readonly IOffersRepository _offersRepository;
    private readonly ICompaniesRepository _companiesRepository;
    private readonly ILocationsRepository _locationsRepository;
    private readonly ICategoriesRepository _categoriesRepository;
    private readonly IWorkingTimesRepository _workingTimesRepository;
    private readonly ISenioritiesRepository _senioritiesRepository;
    private readonly IMapper _mapper;

    public OffersService(IOffersRepository offersRepository, ICompaniesRepository companiesRepository, ILocationsRepository locationsRepository, ICategoriesRepository categoriesRepository, IWorkingTimesRepository workingTimesRepository, ISenioritiesRepository senioritiesRepository, IMapper mapper)
    {
        _offersRepository = offersRepository;
        _companiesRepository = companiesRepository;
        _locationsRepository = locationsRepository;
        _categoriesRepository = categoriesRepository;
        _workingTimesRepository = workingTimesRepository;
        _senioritiesRepository = senioritiesRepository;
        _mapper = mapper;
    }

    public async Task<ICollection<OfferDto>> GetOffersAsync()
    {
        var offers = await _offersRepository.GetOffersAsync();

        return _mapper.Map<ICollection<OfferDto>>(offers);
    }

    public async Task<OfferDto> GetOfferAsync(int id)
    {
        var offer = await _offersRepository.GetOfferAsync(id);

        if (offer == null)
            throw new NotFoundException(NOT_FOUND_MESSAGE);

        return _mapper.Map<OfferDto>(offer);
    }

    public async Task<OfferDto> CreateOfferAsync(RequestOfferDto requestOfferDto)
    {
        Offer offerToCreate = new();

        offerToCreate.Title = requestOfferDto.Title;

        var company = await _companiesRepository.GetCompanyAsync(requestOfferDto.CompanyName);
        company ??= await _companiesRepository.CreateCompanyAsync(new Company() { Name = requestOfferDto.CompanyName });

        offerToCreate.CompanyId = company.Id;

        var location = await _locationsRepository.GetLocationAsync(requestOfferDto.LocationName);
        location ??= await _locationsRepository.CreateLocationAsync(new Location() { Name = requestOfferDto.LocationName });

        offerToCreate.LocationId = location.Id;

        var category = await _categoriesRepository.GetCategoryAsync(requestOfferDto.CategoryName);
        category ??= await _categoriesRepository.CreateCategoryAsync(new Category() { Name = requestOfferDto.CategoryName });

        offerToCreate.CategoryId = category.Id;

        var workingTime = await _workingTimesRepository.GetWorkingTimeAsync(requestOfferDto.WorkingTimeName);
        workingTime ??= await _workingTimesRepository.CreateWorkingTimeAsync(new WorkingTime() { Name = requestOfferDto.WorkingTimeName });

        offerToCreate.WorkingTimeId = workingTime.Id;

        if (!string.IsNullOrEmpty(requestOfferDto.SeniorityName))
        {
            var seniority = await _senioritiesRepository.GetSeniorityAsync(requestOfferDto.SeniorityName);
            seniority ??= await _senioritiesRepository.CreateSeniorityAsync(new Seniority() { Name = requestOfferDto.SeniorityName });

            offerToCreate.SeniorityId = seniority.Id;
        }

        offerToCreate.SalaryMin = requestOfferDto.SalaryMin;
        offerToCreate.SalaryMax = requestOfferDto.SalaryMax;
        offerToCreate.Date = requestOfferDto.Date;
        offerToCreate.Views = requestOfferDto.Views;
        offerToCreate.Url = requestOfferDto.Url;

        var createdOffer = await _offersRepository.CreateOfferAsync(offerToCreate);

        return _mapper.Map<OfferDto>(createdOffer);
    }

    public async Task UpdateOfferAsync(int id, RequestOfferDto requestOfferDto)
    {
        throw new NotImplementedException();
        //var offerToUpdate = await _offersRepository.GetOfferAsync(id);

        //if (offerToUpdate == null)
        //    throw new NotFoundException(NOT_FOUND_MESSAGE);

        //var updatedOffer = _mapper.Map<Offer>(requestOfferDto);
        //await _offersRepository.UpdateOfferAsync(id, updatedOffer);
    }

    public async Task DeleteOfferAsync(int id)
    {
        var offerToUpdate = await _offersRepository.GetOfferAsync(id);

        if (offerToUpdate == null)
            throw new NotFoundException(NOT_FOUND_MESSAGE);

        await _offersRepository.DeleteOfferAsync(id);
    }
}
