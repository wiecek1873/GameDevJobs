using AutoMapper;
using Backend.Application.Dto.Companies;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Entities;
using Backend.Domain.Interfaces;
using GameDevJobs.Application.Exceptions;

namespace Backend.Application.Services;
public class CompaniesService : ICompaniesService
{
    private const string NOT_FOUND_MESSAGE = "Company with this id does not exist.";

    private readonly ICompaniesRepository _companiesRepository;
    private readonly IMapper _mapper;

    public CompaniesService(ICompaniesRepository companiesRepository, IMapper mapper)
    {
        _companiesRepository = companiesRepository;
        _mapper = mapper;
    }

    public async Task<ICollection<CompanyDto>> GetCompaniesAsync()
    {
        var companies = await _companiesRepository.GetCompaniesAsync();
        return _mapper.Map<ICollection<CompanyDto>>(companies);
    }

    public async Task<CompanyDto> GetCompanyAsync(int id)
    {
        var company = await _companiesRepository.GetCompanyAsync(id);

        if (company == null)
            throw new NotFoundException(NOT_FOUND_MESSAGE);

        return _mapper.Map<CompanyDto>(company);
    }

    public async Task<CompanyDto> CreateCompanyAsync(RequestCompanyDto requestCompanyDto)
    {
        var companyToCreate = _mapper.Map<Company>(requestCompanyDto);
        companyToCreate = await _companiesRepository.CreateCompanyAsync(companyToCreate);

        return _mapper.Map<CompanyDto>(companyToCreate);
    }

    public async Task UpdateCompanyAsync(int id, RequestCompanyDto requestCompanyDto)
    {
        if (await _companiesRepository.GetCompanyAsync(id) == null)
            throw new NotFoundException(NOT_FOUND_MESSAGE);

        var updatedCompany = _mapper.Map<Company>(requestCompanyDto);
        await _companiesRepository.UpdateCompanyAsync(id, updatedCompany);
    }

    public async Task DeleteCompanyAsync(int id)
    {
        if (await _companiesRepository.GetCompanyAsync(id) == null)
            throw new NotFoundException(NOT_FOUND_MESSAGE);

        await _companiesRepository.DeleteCompanyAsync(id);
    }
}
