using GameDevJobs.Domain.Entities;

namespace GameDevJobs.Domain.Interfaces;

public interface ICategoriesRepository
{
    Task<Category?> CreateCategory(Category newCategory);

    Task<ICollection<Category>?> GetCategories();
    
    Task<Category?> GetCategory(int id);
    
    Task UpdateCategory(int id, Category updatedCategory);
    
    Task DeleteCategory(int id);
}