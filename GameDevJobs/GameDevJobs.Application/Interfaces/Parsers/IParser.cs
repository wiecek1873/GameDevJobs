namespace GameDevJobs.Application.Interfaces.Parsers;

public interface IParser
{
    Task<string> Parse(string input);
}
