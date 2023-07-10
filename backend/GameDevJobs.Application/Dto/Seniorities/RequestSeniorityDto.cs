using System.ComponentModel.DataAnnotations;

namespace GameDevJobs.Application.Dto.Seniorities;
public class RequestSeniorityDto
{
    [Required(ErrorMessage = "Location name is required")]
    public string Name { get; set; } = null!;
}
