using GameDevJobs.Application.Dto.Companies;
using GameDevJobs.Application.Dto.Offers;
using GameDevJobs.Application.Interfaces.Parsers;
using HtmlAgilityPack;

namespace GameDevJobs.Application.Parsers;

public class SkillshotOfferParser : IParser<RequestOfferDto>
{
    public RequestOfferDto Parse(string html)
    {
        HtmlDocument htmlDocument = new();
        htmlDocument.LoadHtml(html);

        var companyDto = new RequestOfferDto()
        {
            Title = parseTitle(htmlDocument),
            CompanyName = parseCompanyName(htmlDocument),
            LocationName = parseLocationName(htmlDocument),
            CategoryName = parseCategoryName(htmlDocument),
            WorkingTimeName = parseWorkingTimeName(htmlDocument),
            SeniorityName = parseSeniorityName(htmlDocument),
            SalaryMin = parseSalaryMin(htmlDocument),
            SalaryMax = parseSalaryMax(htmlDocument),
            Date = parseDate(htmlDocument),
            Views = parseViews(htmlDocument),
        };

        return companyDto;
    }

    private string parseTitle(HtmlDocument htmlDocument)
    {
        return htmlDocument.DocumentNode.SelectSingleNode("//*[@id=\"job_presentation\"]/h1").InnerText.Replace("\n", String.Empty);
    }

    private string parseCompanyName(HtmlDocument htmlDocument)
    {
        if (htmlDocument.DocumentNode.SelectSingleNode("//*[@id=\"job_presentation\"]/p[1]/span[3]")?.InnerText == "opublikowane przez")
            return htmlDocument.DocumentNode.SelectSingleNode("//*[@id=\"job_presentation\"]/p[1]/b[1]").InnerText.Replace("\n", String.Empty);
        else
            return htmlDocument.DocumentNode.SelectSingleNode("//*[@id=\"job_presentation\"]/p[1]/b/a").InnerText.Replace("\n", String.Empty);
    }

    private string parseLocationName(HtmlDocument htmlDocument)
    {
        if (htmlDocument.DocumentNode.SelectSingleNode("//*[@id=\"job_presentation\"]/p[1]/span[3]")?.InnerText == "opublikowane przez")
            return htmlDocument.DocumentNode.SelectSingleNode("//*[@id=\"job_presentation\"]/p[1]/b[2]").InnerText.Replace("\n", String.Empty);
        else
            return htmlDocument.DocumentNode.SelectSingleNode("//*[@id=\"job_presentation\"]/p[1]/span[2]").NextSibling.InnerText;
    }

    private string parseCategoryName(HtmlDocument htmlDocument)
    {
        return htmlDocument.DocumentNode.SelectSingleNode("//*[@id=\"job_presentation\"]/p[2]/span[2]").InnerText.Replace("\n", String.Empty);
    }

    private string parseWorkingTimeName(HtmlDocument htmlDocument)
    {
        return htmlDocument.DocumentNode.SelectSingleNode("//*[@id=\"job_presentation\"]/p[2]/span[1]").InnerText.Replace("\n", String.Empty);
    }

    private string? parseSeniorityName(HtmlDocument htmlDocument)
    {
        return string.Empty;
        //return htmlDocument.DocumentNode.SelectSingleNode("")?.InnerText;
    }

    private int? parseSalaryMin(HtmlDocument htmlDocument)
    {
        return 0;
        //return int.Parse(htmlDocument.DocumentNode.SelectSingleNode("")?.InnerText);
    }

    private int? parseSalaryMax(HtmlDocument htmlDocument)
    {
        return 0;
        //return int.Parse(htmlDocument.DocumentNode.SelectSingleNode("")?.InnerText);
    }

    private DateOnly parseDate(HtmlDocument htmlDocument)
    {
        return DateOnly.Parse(htmlDocument.DocumentNode.SelectSingleNode("//*[@id=\"job_presentation\"]/p[3]/strong").InnerText);
    }

    private int parseViews(HtmlDocument htmlDocument)
    {
        return int.Parse(htmlDocument.DocumentNode.SelectSingleNode("//*[@id=\"job_presentation\"]/p[4]/strong").InnerText);
    }
}
