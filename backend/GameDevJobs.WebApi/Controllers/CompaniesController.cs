using GameDevJobs.Application.Dto.Companies;
using GameDevJobs.Application.Interfaces.Services;
using GameDevJobs.WebApi.Filters;
using Microsoft.AspNetCore.Mvc;

namespace GameDevJobs.WebApi.Controllers;

[ApiController]
[GlobalExceptionFilter]
[Route("api/[controller]")]
public class CompaniesController : ControllerBase
{
    private readonly ICompaniesService _companiesService;

    public CompaniesController(ICompaniesService companiesService)
    {
        _companiesService = companiesService;
    }

    [HttpGet]
    public async Task<IActionResult> GetCompanies()
    {
        var companies = await _companiesService.GetCompaniesAsync();

        return Ok(companies);
    }

    [HttpGet("{companyId}")]
    public async Task<IActionResult> GetCompany(int companyId)
    {
        var company = await _companiesService.GetCompanyAsync(companyId);

        return Ok(company);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCompany([FromBody] RequestCompanyDto requestCompanyDto)
    {
        var newCompany = await _companiesService.CreateCompanyAsync(requestCompanyDto);

        return Created($"api/companies/{newCompany.Id}", newCompany);
    }

    [HttpPut("{companyId}")]
    public async Task<IActionResult> UpdateCompany([FromRoute] int companyId, [FromBody] RequestCompanyDto updatedCompanyDto)
    {
        await _companiesService.UpdateCompanyAsync(companyId, updatedCompanyDto);

        return NoContent();
    }

    [HttpDelete("{companyId}")]
    public async Task<IActionResult> DeleteCategory(int companyId)
    { 
        await _companiesService.DeleteCompanyAsync(companyId);

        return Ok();
    }
}
