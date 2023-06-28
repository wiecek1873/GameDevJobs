using GameDevJobs.Application.Dto.Offers;

namespace GameDevJobs.Application.Interfaces.Parsers;

public interface IParser<T>
{
    T Parse(string html);
}
