using GameDevJobs.Data;
using GameDevJobs.Domain.Entities;
using GameDevJobs.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GameDevJobs.Infrastructure.Repositories;
public class CompaniesRepository : ICompaniesRepository
{
    private readonly GameDevJobsContext _gameDevJobsContext;

    public CompaniesRepository(GameDevJobsContext gameDevJobsContext)
    {
        _gameDevJobsContext =        gameDevJobsContext;
    }

    public async Task<ICollection<Company>?> GetCompaniesAsync()
    {
        return await _gameDevJobsContext.Companies.ToListAsync();
    }

    public async Task<Company?> GetCompanyAsync(int id)
    {
        return await _gameDevJobsContext.Companies.SingleOrDefaultAsync(c => c.Id == id);
    }

    public async Task<Company?> GetCompanyAsync(string name)
    {
        return await _gameDevJobsContext.Companies.SingleOrDefaultAsync(c => c.Name == name);
    }

    public async Task<Company?> CreateCompanyAsync(Company company)
    {
        await _gameDevJobsContext.Companies.AddAsync(company);
        await _gameDevJobsContext.SaveChangesAsync();

        return company;
    }

    public async Task UpdateCompanyAsync(int id, Company updatedCompany)
    {
        var companyToUpdate = await _gameDevJobsContext.Companies.SingleOrDefaultAsync(c => c.Id == id);

        if (companyToUpdate == null)
            return;

        companyToUpdate.Name = updatedCompany.Name;
        companyToUpdate.Description = updatedCompany.Description;
        companyToUpdate.Website = updatedCompany.Website;

        await _gameDevJobsContext.SaveChangesAsync();
    }

    public async Task DeleteCompanyAsync(int id)
    {
        var comapnyToDelete = await _gameDevJobsContext.Companies.SingleOrDefaultAsync(c => c.Id == id);

        if (comapnyToDelete == null)
            return;

        _gameDevJobsContext.Companies.Remove(comapnyToDelete);
        await _gameDevJobsContext.SaveChangesAsync();
    }
}
