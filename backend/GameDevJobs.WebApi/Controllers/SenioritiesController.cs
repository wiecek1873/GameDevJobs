using GameDevJobs.Application.Dto.Locations;
using GameDevJobs.Application.Dto.Seniorities;
using GameDevJobs.Application.Interfaces.Services;
using GameDevJobs.WebApi.Filters;
using Microsoft.AspNetCore.Mvc;

namespace GameDevJobs.WebApi.Controllers;
[ApiController]
[GlobalExceptionFilter]
[Route("api/[controller]")]
public class SenioritiesController : ControllerBase
{
    private readonly ISenioritiesService _seniorityService;

    public SenioritiesController(ISenioritiesService seniorityService)
    {
        _seniorityService = seniorityService;
    }

    [HttpGet]
    public async Task<IActionResult> GetSeniorities()
    {
        var seniorities = await _seniorityService.GetSeniorityAsync();

        return Ok(seniorities);
    }

    [HttpGet("{seniorityId}")]
    public async Task<IActionResult> GetSeniority(int seniorityId)
    {
        var seniority = await _seniorityService.GetSeniorityAsync(seniorityId);

        return Ok(seniority);
    }

    [HttpPost]
    public async Task<IActionResult> CreateSeniority([FromBody] RequestSeniorityDto requestSeniorityDto)
    {
        var newSeniority = await _seniorityService.CreateSeniorityAsync(requestSeniorityDto);

        return Created($"api/seniorities/{newSeniority.Id}", newSeniority);
    }

    [HttpPut("{seniorityId}")]
    public async Task<IActionResult> UpdateSeniority([FromRoute] int seniorityId, [FromBody] RequestSeniorityDto requestSeniorityDto)
    {
        await _seniorityService.UpdateSeniorityAsync(seniorityId, requestSeniorityDto);

        return NoContent();
    }

    [HttpDelete("{seniorityId}")]
    public async Task<IActionResult> DeleteSeniority(int seniorityId)
    {
        await _seniorityService.DeleteSeniorityAsync(seniorityId);

        return Ok();
    }
}