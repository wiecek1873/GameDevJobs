using Backend.Application.Dto.Companies;
using Scraper.WebApi.Interfaces;

namespace Scraper.WebApi.Services;
public class SkillshotScraperService : IScraperService
{
    private readonly HttpClient _httpClient;

    public SkillshotScraperService(HttpClient httpClient)
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
