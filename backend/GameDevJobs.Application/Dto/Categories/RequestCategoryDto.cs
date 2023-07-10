using System.ComponentModel.DataAnnotations;

namespace GameDevJobs.Application.Dto.Categories;
public class RequestCategoryDto
{
    [Required(ErrorMessage = "Category name is required")]
    public string Name { get; set; } = null!;
}
