using GameDevJobs.Domain.Entities;
namespace GameDevJobs.Domain.Interfaces;

public interface ISenioritiesRepository
{
    Task<ICollection<Seniority>?> GetSenioritiesAsync();
    Task<Seniority?> GetSeniorityAsync(int id);
    Task<Seniority?> GetSeniorityAsync(string name);
    Task<Seniority?> CreateSeniorityAsync(Seniority newSeniority);
    Task UpdateSeniorityAsync(int id, Seniority updatedSeniority);
    Task DeleteSeniorityAsync(int id);
}
