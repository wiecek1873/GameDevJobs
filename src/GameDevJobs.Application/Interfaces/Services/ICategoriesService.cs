using Backend.Application.Dto.Categories;

namespace Backend.Application.Interfaces.Services;
public interface ICategoriesService
{
    Task<ICollection<CategoryDto>> GetCategoriesAsync();

    Task<CategoryDto> GetCategoryAsync(int categoryId);

    Task<CategoryDto> GetCategoryAsync(string name);

    Task<CategoryDto> CreateCategoryAsync(RequestCategoryDto newCategoryDto);

    Task UpdateCategoryAsync(int categoryId, RequestCategoryDto updatedCategoryDto);

    Task DeleteCategoryAsync(int categoryId);
}
