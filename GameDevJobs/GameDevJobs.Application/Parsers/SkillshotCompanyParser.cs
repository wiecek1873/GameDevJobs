using GameDevJobs.Application.Dto.Companies;
using GameDevJobs.Application.Interfaces.Parsers;
using HtmlAgilityPack;

namespace GameDevJobs.Application.Parsers;

public class SkillshotCompanyParser : IParser<RequestCompanyDto>
{
    public RequestCompanyDto Parse(string html)
    {
        HtmlDocument htmlDocument = new();
        htmlDocument.LoadHtml(html);

        var companyDto = new RequestCompanyDto
        {
            Name = parseName(htmlDocument),
            Description = parseDescription(htmlDocument),
            Website = parseWebsite(htmlDocument)
        };

        return companyDto;
    }

    private string parseName(HtmlDocument htmlDocument)
    {
        return htmlDocument.DocumentNode.SelectSingleNode("/html/body/div[2]/h1[1]").InnerText.Replace("\n", String.Empty);
    }

    private string? parseDescription(HtmlDocument htmlDocument)
    {
        return htmlDocument.DocumentNode.SelectSingleNode("/html/body/div[2]/div/p/text()")?.InnerText;
    }

    private string? parseWebsite(HtmlDocument htmlDocument)
    {
        return htmlDocument.DocumentNode.SelectSingleNode("/html/body/div[2]/p[2]/b/a")?.InnerText;
    }
}
