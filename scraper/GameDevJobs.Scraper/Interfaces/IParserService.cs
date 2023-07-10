namespace Scraper.WebApi.Interfaces;

public interface IParserService<T>
{
    T Parse(string html);
}
