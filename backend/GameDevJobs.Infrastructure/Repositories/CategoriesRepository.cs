using GameDevJobs.Data;
using GameDevJobs.Domain.Entities;
using GameDevJobs.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GameDevJobs.Infrastructure.Repositories;
public class CategoriesRepository : ICategoriesRepository
{
    private readonly GameDevJobsContext _gameDevJobsContext;

    public CategoriesRepository(GameDevJobsContext gameDevJobsContext)
    {
        _gameDevJobsContext = gameDevJobsContext;
    }

    //todo Should i use ICollection<Category> or List<Category> in this case?
    public async Task<ICollection<Category>?> GetCategoriesAsync()
    {
        return await _gameDevJobsContext.Categories.ToListAsync();
    }

    //todo Should this be marked as nullable?
    public async Task<Category?> GetCategoryAsync(int id)
    {
        return await _gameDevJobsContext.Categories.SingleOrDefaultAsync(c => c.Id == id);
    }

    public async Task<Category?> GetCategoryAsync(string name)
    {
        return await _gameDevJobsContext.Categories.SingleOrDefaultAsync(c => c.Name == name);
    }

    public async Task<Category?> CreateCategoryAsync(Category newCategory)
    {
        await _gameDevJobsContext.Categories.AddAsync(newCategory); //todo Should I use AddAsync() or Add()?
        await _gameDevJobsContext.SaveChangesAsync();

        return newCategory;
    }

    public async Task UpdateCategoryAsync(int id, Category updatedCategory)
    {
        var categoryToUpdate = await _gameDevJobsContext.Categories.SingleOrDefaultAsync(c => c.Id == id);

        if (categoryToUpdate != null)
            categoryToUpdate.Name = updatedCategory.Name;

        await _gameDevJobsContext.SaveChangesAsync();
    }

    public async Task DeleteCategoryAsync(int id)
    {
        var categoryToDelete = await _gameDevJobsContext.Categories.SingleOrDefaultAsync(c => c.Id == id);

        if (categoryToDelete != null)
            _gameDevJobsContext.Categories.Remove(categoryToDelete);

        await _gameDevJobsContext.SaveChangesAsync();
    }
}
