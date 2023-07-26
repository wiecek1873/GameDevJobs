using Backend.Domain.Entities;
using Backend.Domain.Interfaces;
using Backend.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Repositories;
public class WorkingTimesRepository : IWorkingTimesRepository
{
    private readonly GameDevJobsContext _gameDevJobsContext;

    public WorkingTimesRepository(GameDevJobsContext gameDevJobsContext)
    {
        _gameDevJobsContext = gameDevJobsContext;
    }

    public async Task<ICollection<WorkingTime>?> GetWorkingTimesAsync()
    {
        return await _gameDevJobsContext.WorkingTimes.ToListAsync();
    }

    public async Task<WorkingTime?> GetWorkingTimeAsync(int id)
    {
        return await _gameDevJobsContext.WorkingTimes.SingleOrDefaultAsync(w => w.Id == id);
    }

    public async Task<WorkingTime?> GetWorkingTimeAsync(string name)
    {
        return await _gameDevJobsContext.WorkingTimes.SingleOrDefaultAsync(w => w.Name == name);
    }

    public async Task<WorkingTime?> CreateWorkingTimeAsync(WorkingTime newWorkingTime)
    {
        await _gameDevJobsContext.WorkingTimes.AddAsync(newWorkingTime);
        await _gameDevJobsContext.SaveChangesAsync();

        return newWorkingTime;
    }

    public async Task UpdateWorkingTimeAsync(int id, WorkingTime updatedWorkingTime)
    {
        var workingTimeToUpdate = await _gameDevJobsContext.WorkingTimes.SingleOrDefaultAsync(w => w.Id == id);

        if (workingTimeToUpdate == null)
        {
            return; //Todo Should I throw an excpetion or just don't care?
        }

        workingTimeToUpdate.Name = updatedWorkingTime.Name;
        await _gameDevJobsContext.SaveChangesAsync();
    }

    public async Task DeleteWorkingTimeAsync(int id)
    {
        var workingTimeToDelete = await _gameDevJobsContext.WorkingTimes.SingleOrDefaultAsync(w => w.Id ==id);

        if (workingTimeToDelete == null)
        {
            return;
        }

        _gameDevJobsContext.WorkingTimes.Remove(workingTimeToDelete);
        await _gameDevJobsContext.SaveChangesAsync();
    }
}
