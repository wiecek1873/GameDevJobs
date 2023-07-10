using Backend.Application.Dto.Locations;
using GameDevJobs.Application.Dto.Categories;

namespace Backend.Application.Interfaces.Services;
public interface ILocationsService
{
    Task<ICollection<LocationDto>> GetLocationsAsync();
    Task<LocationDto> GetLocationAsync(int id);
    Task<LocationDto> CreateLocationAsync(RequestLocationDto newLocationDto);
    Task UpdateLocationAsync(int id, RequestLocationDto updatedLocation);
    Task DeleteLocationAsync(int id);
}
