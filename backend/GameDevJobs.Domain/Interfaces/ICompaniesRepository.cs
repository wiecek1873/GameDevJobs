using Backend.Domain.Entities;

namespace Backend.Domain.Interfaces;
public interface ICompaniesRepository
{
    Task<ICollection<Company>?> GetCompaniesAsync();
    Task<Company?> GetCompanyAsync(int id);
    Task<Company?> GetCompanyAsync(string name);
    Task<Company?> CreateCompanyAsync(Company newCompany);
    Task UpdateCompanyAsync(int id, Company updatedCompany);
    Task DeleteCompanyAsync(int id);
}
