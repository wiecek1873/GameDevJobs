using GameDevJobs.Data;
using GameDevJobs.Domain.Entities;
using GameDevJobs.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GameDevJobs.Infrastructure.Repositories;
public class LocationsRepository : ILocationsRepository
{
    private readonly GameDevJobsContext _gameDevJobsContext;

    public LocationsRepository(GameDevJobsContext gameDevJobsContext)
    {
        _gameDevJobsContext = gameDevJobsContext;
    }

    public async Task<ICollection<Location>?> GetLocationsAsync()
    {
        return await _gameDevJobsContext.Locations.ToListAsync();
    }

    public async Task<Location?> GetLocationAsync(int id)
    {
        return await _gameDevJobsContext.Locations.SingleOrDefaultAsync(l => l.Id == id);
    }

    public async Task<Location?> GetLocationAsync(string name)
    {
        return await _gameDevJobsContext.Locations.SingleOrDefaultAsync(l => l.Name == name);
    }

    public async Task<Location?> CreateLocationAsync(Location newLocation)
    {
        await _gameDevJobsContext.Locations.AddAsync(newLocation);
        await _gameDevJobsContext.SaveChangesAsync();

        return newLocation;
    }

    public async Task UpdateLocationAsync(int id, Location updatedLocation)
    {
        var locationToUpdate = await _gameDevJobsContext.Locations.SingleOrDefaultAsync(l => l.Id ==  id);

        if(locationToUpdate != null) 
        {
            locationToUpdate.Name = updatedLocation.Name;
        }

        await _gameDevJobsContext.SaveChangesAsync();
    }

    public async Task DeleteLocationAsync(int id)
    {
        var locationToDelete = await _gameDevJobsContext.Locations.SingleOrDefaultAsync(l => l.Id == id);

        if(locationToDelete != null) 
        {
            _gameDevJobsContext.Locations.Remove(locationToDelete);
        }

        await _gameDevJobsContext.SaveChangesAsync();
    }
}
