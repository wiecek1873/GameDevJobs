using GameDevJobs.Application.Interfaces.Scrapers;

namespace GameDevJobs.Application.Scrapers;

public class SkillshotScraper : IScraper
{
    private readonly HttpClient _httpClient;

    public SkillshotScraper(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string> CallUrlAsync(string url)
    {
        using var response = await _httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadAsStringAsync();
    }
}
