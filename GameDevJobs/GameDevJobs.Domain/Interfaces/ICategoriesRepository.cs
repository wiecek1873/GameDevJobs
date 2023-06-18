using GameDevJobs.Domain.Entities;
using System.Threading.Tasks;

namespace GameDevJobs.Domain.Interfaces;

public interface ICategoriesRepository
{
    Task<Category?> AddCategory(Category newCategory);
    Task<ICollection<Category>?> GetCategories();
    Task<Category?> GetCategory(int id);
    Task<Category?> UpdateCategory(int id, Category updatedCategory);
    Task DeleteCategory(int id);
}