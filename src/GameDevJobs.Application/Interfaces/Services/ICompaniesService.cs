using Backend.Application.Dto.Companies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.Interfaces.Services;
public interface ICompaniesService
{
    Task<ICollection<CompanyDto>> GetCompaniesAsync();
    Task<CompanyDto> GetCompanyAsync(int id);
    Task<CompanyDto> CreateCompanyAsync(RequestCompanyDto requestCompanyDto);
    Task UpdateCompanyAsync(int id, RequestCompanyDto requestCompanyDto);
    Task DeleteCompanyAsync(int id);
}
