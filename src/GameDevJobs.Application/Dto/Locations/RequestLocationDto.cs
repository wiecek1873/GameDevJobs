using System.ComponentModel.DataAnnotations;

namespace Backend.Application.Dto.Locations;
public class RequestLocationDto
{
    [Required(ErrorMessage = "Location name is required")]
    public string Name { get; set; } = null!;
}
