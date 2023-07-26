using Backend.Application.Dto.Seniorities;

namespace Backend.Application.Interfaces.Services;
public interface ISenioritiesService
{
    Task<ICollection<SeniorityDto>> GetSeniorityAsync();
    Task<SeniorityDto> GetSeniorityAsync(int id);
    Task<SeniorityDto> CreateSeniorityAsync(RequestSeniorityDto newSeniorityDto);
    Task UpdateSeniorityAsync(int id, RequestSeniorityDto updatedSeniorityDto);
    Task DeleteSeniorityAsync(int id);
}
