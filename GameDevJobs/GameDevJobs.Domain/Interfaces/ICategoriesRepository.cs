using GameDevJobs.Domain.Entities;

namespace GameDevJobs.Domain.Interfaces;

public interface ICategoriesRepository
{
    Task<ICollection<Category>?> GetCategories();
 
    Task<Category?> GetCategory(int id);

    Task<Category?> GetCategory(string name);
    
    Task<Category?> CreateCategory(Category newCategory);
    
    Task UpdateCategory(int id, Category updatedCategory);
    
    Task DeleteCategory(int id);
}