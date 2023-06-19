using GameDevJobs.Domain.Entities;

namespace GameDevJobs.Domain.Interfaces;

public interface ILocationsRepository
{
    Task<ICollection<Location>?> GetLocationsAsync();
    Task<Location?> GetLocationAsync(int id);
    Task<Location?> GetLocationAsync(string name);
    Task<Location?> CreateLocationAsync(Location newLocation);
    Task UpdateLocationAsync(int id, Location updatedLocation);
    Task DeleteLocationAsync(int id);
}
