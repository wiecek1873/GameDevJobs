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

    public async Task<Category?> AddCategory(Category newCategory)
    {
        throw new NotImplementedException();
    }

    //todo Should i use ICollection<Category> or List<Category> in this case?
    public async Task<ICollection<Category>?> GetCategories()
    {
        return await _gameDevJobsContext.Categories.ToListAsync();
    }

    //todo Should this be marked as nullable?
    public async Task<Category?> GetCategory(int id)
    {
        return await _gameDevJobsContext.Categories.SingleOrDefaultAsync(c => c.Id == id);
    }

    public async Task<Category?> UpdateCategory(int id, Category updatedCategory)
    {
        throw new NotImplementedException();
    }

    public Task DeleteCategory(int id)
    {
        throw new NotImplementedException();
    }

}
