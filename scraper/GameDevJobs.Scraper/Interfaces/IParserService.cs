namespace GameDevJobs.Scraper.Interfaces;

public interface IParserService<T>
{
    T Parse(string html);
}
