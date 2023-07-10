using AutoMapper;
using GameDevJobs.Application.Dto.Locations;
using GameDevJobs.Application.Exceptions;
using GameDevJobs.Application.Interfaces.Services;
using GameDevJobs.Domain.Entities;
using GameDevJobs.Domain.Interfaces;

namespace GameDevJobs.Application.Services;
public class LocationsService : ILocationsService
{
    private const string NOT_FOUND_MESSAGE = "Location with this id does not exist.";
    private const string CONFLICT_MESSAGE = "Location with this name already exist.";

    private readonly ILocationsRepository _locationsRepository;
    private readonly IMapper _mapper;

    public LocationsService(ILocationsRepository locationsRepository, IMapper mapper)
    {
        _locationsRepository = locationsRepository;
        _mapper = mapper;
    }

    public async Task<ICollection<LocationDto>> GetLocationsAsync()
    {
        var locations = await _locationsRepository.GetLocationsAsync();

        return _mapper.Map<ICollection<LocationDto>>(locations);
    }

    public async Task<LocationDto> GetLocationAsync(int id)
    {
        var location = await _locationsRepository.GetLocationAsync(id);

        if (location == null)
            throw new NotFoundException(NOT_FOUND_MESSAGE);

        return _mapper.Map<LocationDto>(location);
    }

    public async Task<LocationDto> CreateLocationAsync(RequestLocationDto newLocationDto)
    {
        if (await _locationsRepository.GetLocationAsync(newLocationDto.Name) != null)
            throw new ConflictException(CONFLICT_MESSAGE);

        var newLocation = _mapper.Map<Location>(newLocationDto);
        newLocation = await _locationsRepository.CreateLocationAsync(newLocation);

        return _mapper.Map<LocationDto>(newLocation);
    }

    public async Task UpdateLocationAsync(int id, RequestLocationDto updatedLocationDto)
    {
        var locationToUpdate = await _locationsRepository.GetLocationAsync(id);

        if (locationToUpdate == null)
            throw new NotFoundException(NOT_FOUND_MESSAGE);

        locationToUpdate = _mapper.Map<Location>(updatedLocationDto);

        await _locationsRepository.UpdateLocationAsync(id, locationToUpdate);
    }

    public async Task DeleteLocationAsync(int id)
    {
        var locationDoDelete = await _locationsRepository.GetLocationAsync(id);

        if (locationDoDelete == null)
            throw new NotFoundException(NOT_FOUND_MESSAGE);

        await _locationsRepository.DeleteLocationAsync(id);
    }
}
