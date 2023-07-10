using System.ComponentModel.DataAnnotations;

namespace GameDevJobs.Application.Dto.WorkingTimes;

public class RequestWorkingTimeDto
{
    [Required(ErrorMessage = "Location name is required")]
    public string Name { get; set; } = null!;
}
