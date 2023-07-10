﻿using Backend.Application.Dto.Companies;
using Scraper.WebApi.Interfaces;

namespace Scraper.WebApi.Services;
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
