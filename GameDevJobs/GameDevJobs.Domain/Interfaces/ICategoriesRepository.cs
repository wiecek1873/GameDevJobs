using GameDevJobs.Domain.Entities;

namespace GameDevJobs.Domain.Interfaces;

public interface ICategoriesRepository
{
    Task<ICollection<Category>?> GetCategoriesAsync();
 
    Task<Category?> GetCategoryAsync(int id);

    Task<Category?> GetCategoryAsync(string name);
    
    Task<Category?> CreateCategoryAsync(Category newCategory);
    
    Task UpdateCategoryAsync(int id, Category updatedCategory);
    
    Task DeleteCategoryAsync(int id);
}