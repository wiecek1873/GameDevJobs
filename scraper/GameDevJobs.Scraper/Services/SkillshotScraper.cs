using GameDevJobs.Application.Dto.Companies;
using GameDevJobs.Scraper.Interfaces;

namespace GameDevJobs.Application.Scrapers;

public class SkillshotScraper : IScraperService
{
    private readonly HttpClient _httpClient;

    public SkillshotScraper(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string> CallUrlAsync(string url)
    {
        using var response = await _httpClient.GetAsync(url);
        var xd = response.StatusCode;
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadAsStringAsync();
    }
}
