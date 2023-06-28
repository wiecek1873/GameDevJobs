namespace GameDevJobs.Application.Dto.Offers;

public class OfferDto
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public int CompanyId { get; set; }
    public int LocationId { get; set; }
    public virtual int CategoryId { get; set; }
    public int WorkingTimeId { get; set; }
    public int? SeniorityId { get; set; }
    public int? SalaryMin { get; set; }
    public int? SalaryMax { get; set; }
    public DateOnly Date { get; set; }
    public int Views { get; set; }
    public string Url { get; set; } = null!;
}
