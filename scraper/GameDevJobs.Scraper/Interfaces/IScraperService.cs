namespace Scraper.WebApi.Interfaces;

public interface IScraperService
{
    Task<string> CallUrlAsync(string url);
}
