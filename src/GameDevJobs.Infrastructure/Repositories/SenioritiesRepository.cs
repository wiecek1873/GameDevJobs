using Backend.Domain.Entities;
using Backend.Domain.Interfaces;
using Backend.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Repositories;
public class SenioritiesRepository : ISenioritiesRepository
{
    private readonly GameDevJobsContext _gameDevJobsContext;

    public SenioritiesRepository(GameDevJobsContext gameDevJobsContext)
    {
        _gameDevJobsContext = gameDevJobsContext;
    }

    public async Task<ICollection<Seniority>?> GetSenioritiesAsync()
    {
        return await _gameDevJobsContext.Seniorities.ToListAsync();
    }

    public async Task<Seniority?> GetSeniorityAsync(int id)
    {
        return await _gameDevJobsContext.Seniorities.SingleOrDefaultAsync(s => s.Id == id);
    }

    public async Task<Seniority?> GetSeniorityAsync(string name)
    {
        return await _gameDevJobsContext.Seniorities.SingleOrDefaultAsync(s => s.Name == name);
    }

    public async Task<Seniority?> CreateSeniorityAsync(Seniority newSeniority)
    {
        await _gameDevJobsContext.Seniorities.AddAsync(newSeniority);
        await _gameDevJobsContext.SaveChangesAsync();

        return newSeniority;
    }

    public async Task UpdateSeniorityAsync(int id, Seniority updatedSeniority)
    {
        var seniorityToUpdate = await _gameDevJobsContext.Seniorities.SingleOrDefaultAsync(s => s.Id == id);

        if (seniorityToUpdate == null)
        {
            return;
        }

        seniorityToUpdate.Name = updatedSeniority.Name;
        await _gameDevJobsContext.SaveChangesAsync();
    }

    public async Task DeleteSeniorityAsync(int id)
    {
        var seniorityToDelete = await _gameDevJobsContext.Seniorities.SingleOrDefaultAsync(s => s.Id == id);

        if (seniorityToDelete == null)
        {
            return;
        }

        _gameDevJobsContext.Seniorities.Remove(seniorityToDelete);
        await _gameDevJobsContext.SaveChangesAsync();
    }
}
