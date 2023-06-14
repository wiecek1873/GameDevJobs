namespace GameDevJobs.Models;

public class Offer
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public int CompanyId { get; set; }
    public Company Company { get; set; } = null!;
    public int LocationId { get; set; }
    public Location Location { get; set; } = null!;
    public int CategoryId { get; set; }
    public Category Category { get; set; } = null!;
    public int WorkingTimeId { get; set; }
    public WorkingTime WorkingTime { get; set; } = null!;
    public int? SeniorityId { get; set; }
    public Seniority? Seniority { get; set; }
    public int SalaryMin { get; set; }
    public int SalaryMax { get; set; }
    public DateOnly Date { get; set; }
    public int Views { get; set; }
    public string Url { get; set; } = null!;

}