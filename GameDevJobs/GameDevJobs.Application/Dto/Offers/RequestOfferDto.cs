namespace GameDevJobs.Application.Dto.Offers;

public class RequestOfferDto
{
    public string Title { get; set; } = null!;
    public string Company { get; set; } = null!;
    public string Location { get; set; } = null!;
    public string Category { get; set; } = null!;
    public string WorkingTimeId { get; set; } = null!;
    public string? Seniority { get; set; }
    public int? SalaryMin { get; set; }
    public int? SalaryMax { get; set; }
    public DateOnly Date { get; set; }
    public int Views { get; set; }
    public string Url { get; set; } = null!;
}
