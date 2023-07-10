namespace GameDevJobs.Scraper.Interfaces;

public interface IScraperService
{
    Task<string> CallUrlAsync(string url);
}
