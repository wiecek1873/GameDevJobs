using GameDevJobs.Application.Dto.Seniorities;

namespace GameDevJobs.Application.Interfaces;

public interface ISeniorityService
{
    Task<ICollection<SeniorityDto>> GetSeniorityAsync();
    Task<SeniorityDto> GetSeniorityAsync(int id);
    Task<SeniorityDto> CreateSeniorityAsync(RequestSeniorityDto newSeniorityDto);
    Task UpdateSeniorityAsync(int id, RequestSeniorityDto updatedSeniorityDto);
    Task DeleteSeniorityAsync(int id);
}
