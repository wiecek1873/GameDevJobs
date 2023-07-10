using Backend.Application.Dto.Companies;
using Scraper.WebApi.Interfaces;
using HtmlAgilityPack;

namespace Scraper.WebApi.Services;
public class SkillshotCompanyParserService : IParserService<RequestCompanyDto>
{
    public RequestCompanyDto Parse(string html)
    {
        HtmlDocument htmlDocument = new();
        htmlDocument.LoadHtml(html);

        var companyDto = new RequestCompanyDto
        {
            Name = ParseName(htmlDocument),
            Description = ParseDescription(htmlDocument),
            Website = ParseWebsite(htmlDocument)
        };

        return companyDto;
    }

    private string ParseName(HtmlDocument htmlDocument)
    {
        return htmlDocument.DocumentNode.SelectSingleNode("/html/body/div[2]/h1[1]").InnerText.Replace("\n", string.Empty);
    }

    private string? ParseDescription(HtmlDocument htmlDocument)
    {
        return htmlDocument.DocumentNode.SelectSingleNode("/html/body/div[2]/div/p/text()")?.InnerText;
    }

    private string? ParseWebsite(HtmlDocument htmlDocument)
    {
        return htmlDocument.DocumentNode.SelectSingleNode("/html/body/div[2]/p[2]/b/a")?.InnerText;
    }
}
