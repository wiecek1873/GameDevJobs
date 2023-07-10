using AutoMapper;
using Backend.Application.Dto.WorkingTimes;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Entities;
using Backend.Domain.Interfaces;
using Backend.Application.Exceptions;

namespace Backend.Application.Services;
public class WorkingTimesService : IWorkingTimesService
{
    private const string NOT_FOUND_MESSAGE = "Working time with this id does not exist.";
    private const string CONFLICT_MESSAGE = "Working time with this name already exist.";

    private readonly IWorkingTimesRepository _workingTimesRepository;
    private readonly IMapper _mapper;

    public WorkingTimesService(IWorkingTimesRepository workingTimesRepository, IMapper mapper)
    {
        _workingTimesRepository = workingTimesRepository;
        _mapper = mapper;
    }

    public async Task<ICollection<WorkingTimeDto>> GetWorkingTimesAsync()
    {
        var workingTimes = await _workingTimesRepository.GetWorkingTimesAsync();

        return _mapper.Map<ICollection<WorkingTimeDto>>(workingTimes);
    }

    public async Task<WorkingTimeDto> GetWorkingTimeAsync(int id)
    {
        var workingTime = await _workingTimesRepository.GetWorkingTimeAsync(id);

        if (workingTime == null)
            throw new NotFoundException(NOT_FOUND_MESSAGE);

        return _mapper.Map<WorkingTimeDto>(workingTime);
    }

    public async Task<WorkingTimeDto> CreateWorkingTimeAsync(RequestWorkingTimeDto newWorkingTimeDto)
    {
        if (await _workingTimesRepository.GetWorkingTimeAsync(newWorkingTimeDto.Name) != null)
            throw new ConflictException(CONFLICT_MESSAGE);

        var workingTimeToCreate = _mapper.Map<WorkingTime>(newWorkingTimeDto);
        await _workingTimesRepository.CreateWorkingTimeAsync(workingTimeToCreate);

        return _mapper.Map<WorkingTimeDto>(workingTimeToCreate);
    }

    public async Task UpdateWorkingTimeAsync(int id, RequestWorkingTimeDto updatedWorkingTimeDto)
    {
        if (await _workingTimesRepository.GetWorkingTimeAsync(id) == null)
            throw new NotFoundException(NOT_FOUND_MESSAGE);

        var updatedWorkingTime = _mapper.Map<WorkingTime>(updatedWorkingTimeDto);
        await _workingTimesRepository.UpdateWorkingTimeAsync(id, updatedWorkingTime);
    }

    public async Task DeleteWorkingTimeAsync(int id)
    {
        if (await _workingTimesRepository.GetWorkingTimeAsync(id) == null)
            throw new NotFoundException(NOT_FOUND_MESSAGE);

        await _workingTimesRepository.DeleteWorkingTimeAsync(id);
    }
}
