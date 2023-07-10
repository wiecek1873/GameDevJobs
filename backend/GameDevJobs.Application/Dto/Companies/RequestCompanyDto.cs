using System.ComponentModel.DataAnnotations;

namespace Backend.Application.Dto.Companies;
public class RequestCompanyDto
{
    [Required(ErrorMessage = "Company name is required")]
    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string? Website { get; set; }
}
