using GameDevJobs.Application.Dto.Companies;

namespace GameDevJobs.Application.Interfaces.Scrapers;

public interface IScraper
{
    Task<string> CallUrlAsync(string url);
}
