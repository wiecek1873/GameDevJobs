using GameDevJobs.Application.Dto.WorkingTimes;

namespace GameDevJobs.Application.Interfaces.Services;

public interface IWorkingTimesService
{
    Task<ICollection<WorkingTimeDto>> GetWorkingTimesAsync();
    Task<WorkingTimeDto> GetWorkingTimeAsync(int id);
    Task<WorkingTimeDto> CreateWorkingTimeAsync(RequestWorkingTimeDto newWorkingTimeDto);
    Task UpdateWorkingTimeAsync(int id, RequestWorkingTimeDto updatedWorkingTimeDto);
    Task DeleteWorkingTimeAsync(int id);
}
