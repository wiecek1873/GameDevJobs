using System.ComponentModel.DataAnnotations;

namespace GameDevJobs.Application.Dto.Offers;

public class RequestOfferDto
{
    [Required(ErrorMessage = "Title name is required")]
    public string Title { get; set; } = null!;

    [Required(ErrorMessage = "Company name is required")]
    public string CompanyName { get; set; } = null!;

    [Required(ErrorMessage = "Location name is required")]
    public string LocationName { get; set; } = null!;

    [Required(ErrorMessage = "Category name is required")]
    public string CategoryName { get; set; } = null!;

    [Required(ErrorMessage = "Working time name is required")]
    public string WorkingTimeName { get; set; } = null!;

    public string? SeniorityName { get; set; }

    public int? SalaryMin { get; set; }

    public int? SalaryMax { get; set; }

    //todo Figure out how to validate this
    [Required(ErrorMessage = "Date is required")]
    public DateOnly Date { get; set; }

    [Required(ErrorMessage = "Views count is required")]
    public int Views { get; set; }

    [Url]
    public string Url { get; set; } = null!;
}
