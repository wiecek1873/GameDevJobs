using GameDevJobs.Domain.Entities;

namespace GameDevJobs.Domain.Interfaces;

public interface IWorkingTimesRepository
{
    Task<ICollection<WorkingTime>?> GetWorkingTimesAsync();
    Task<WorkingTime?> GetWorkingTimeAsync(int id);
    Task<WorkingTime?> GetWorkingTimeAsync(string name);
    Task<WorkingTime?> CreateWorkingTimeAsync(WorkingTime newWorkingTime);
    Task UpdateWorkingTimeAsync(int id, WorkingTime updatedWorkingTime);
    Task DeleteWorkingTimeAsync(int id);
}
