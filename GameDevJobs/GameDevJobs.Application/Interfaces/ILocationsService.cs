using GameDevJobs.Application.Dto.Categories;
using GameDevJobs.Application.Dto.Locations;

namespace GameDevJobs.Application.Interfaces;
public interface ILocationsService
{
    Task<ICollection<LocationDto>> GetLocationsAsync();
    Task<LocationDto> GetLocationAsync(int id);
    Task<LocationDto> CreateLocationAsync(RequestLocationDto newLocationDto);
    Task UpdateLocationAsync(int id, RequestLocationDto updatedLocation);
    Task DeleteLocationAsync(int id);
}
