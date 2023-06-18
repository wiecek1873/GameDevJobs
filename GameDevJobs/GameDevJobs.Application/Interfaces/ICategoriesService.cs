using GameDevJobs.Application.Dto.Categories;

namespace GameDevJobs.Application.Interfaces;
public interface ICategoriesService
{
    Task<CategoryDto> CreateCategory(RequestCategoryDto newCategoryDto);
    Task<List<CategoryDto>> GetCategories();
    Task<CategoryDto> GetCategory(int categoryId);
    Task UpdateCategory(int categoryId, RequestCategoryDto updatedCategoryDto);
    Task DeleteCategory(int categoryId);
}
