using AutoMapper;
using GameDevJobs.Application.Dto.Seniorities;
using GameDevJobs.Application.Exceptions;
using GameDevJobs.Application.Interfaces;
using GameDevJobs.Domain.Entities;
using GameDevJobs.Domain.Interfaces;

namespace GameDevJobs.Application.Services;

public class SenioritiesService : ISenioritiesService
{
    private const string NOT_FOUND_MESSAGE = "Seniority with this id does not exist.";
    private const string CONFLICT_MESSAGE = "Seniority with this name already exist.";

    private readonly ISenioritiesRepository _senioritiesRepository;
    private readonly IMapper _mapper;

    public SenioritiesService(ISenioritiesRepository seniorityRepository, IMapper mapper)
    {
        _senioritiesRepository = seniorityRepository;
        _mapper = mapper;
    }

    public async Task<ICollection<SeniorityDto>> GetSeniorityAsync()
    {
        var seniorities = await _senioritiesRepository.GetSenioritiesAsync();

        return _mapper.Map<ICollection<SeniorityDto>>(seniorities);
    }

    public async Task<SeniorityDto> GetSeniorityAsync(int id)
    {
        var seniority = await _senioritiesRepository.GetSeniorityAsync(id);

        if (seniority == null)
            throw new NotFoundException(NOT_FOUND_MESSAGE);

        return _mapper.Map<SeniorityDto>(seniority);
    }

    public async Task<SeniorityDto> CreateSeniorityAsync(RequestSeniorityDto newSeniorityDto)
    {
        if (await _senioritiesRepository.GetSeniorityAsync(newSeniorityDto.Name) != null)
            throw new ConflictException(CONFLICT_MESSAGE);

        var seniorityToCreate = _mapper.Map<Seniority>(newSeniorityDto);
        await _senioritiesRepository.CreateSeniorityAsync(seniorityToCreate);

        return _mapper.Map<SeniorityDto>(seniorityToCreate);
    }

    public async Task UpdateSeniorityAsync(int id, RequestSeniorityDto updatedSeniorityDto)
    {
        if (await _senioritiesRepository.GetSeniorityAsync(id) == null)
            throw new NotFoundException(NOT_FOUND_MESSAGE);

        var updatedSeniority = _mapper.Map<Seniority>(updatedSeniorityDto);
        await _senioritiesRepository.UpdateSeniorityAsync(id, updatedSeniority);
    }

    public async Task DeleteSeniorityAsync(int id)
    {
        if (await _senioritiesRepository.GetSeniorityAsync(id) == null)
            throw new NotFoundException(NOT_FOUND_MESSAGE);

        await _senioritiesRepository.DeleteSeniorityAsync(id);
    }
}
