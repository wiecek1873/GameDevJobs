using Backend.Application.Dto.WorkingTimes;
using Backend.Application.Interfaces.Services;
using GameDevJobs.Application.Dto.Locations;
using GameDevJobs.Application.Dto.Seniorities;
using GameDevJobs.WebApi.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Controllers;
[ApiController]
[GlobalExceptionFilter]
[Route("api/[controller]")]
public class WorkingTimesController : ControllerBase
{
    private readonly IWorkingTimesService _workingTimesService;

    public WorkingTimesController(IWorkingTimesService workingTimesService)
    {
        _workingTimesService = workingTimesService;
    }

    [HttpGet]
    public async Task<IActionResult> GetWorkingTimes()
    {
        var workingTimes = await _workingTimesService.GetWorkingTimesAsync();

        return Ok(workingTimes);
    }

    [HttpGet("{workingTimeId}")]
    public async Task<IActionResult> GetWorkingTime(int workingTimeId)
    {
        var workingTime = await _workingTimesService.GetWorkingTimeAsync(workingTimeId);

        return Ok(workingTime);
    }

    [HttpPost]
    public async Task<IActionResult> CreateWorkingTime([FromBody] RequestWorkingTimeDto requestWorkingTimeDto)
    {
        var newWorkingTime = await _workingTimesService.CreateWorkingTimeAsync(requestWorkingTimeDto);

        return Created($"api/workingTimes/{newWorkingTime.Id}", newWorkingTime);
    }

    [HttpPut("{workingTimeId}")]
    public async Task<IActionResult> UpdateWorkingTime([FromRoute] int workingTimeId, [FromBody] RequestWorkingTimeDto requestWorkingTimeDto)
    {
        await _workingTimesService.UpdateWorkingTimeAsync(workingTimeId, requestWorkingTimeDto);

        return NoContent();
    }

    [HttpDelete("{workingTimeId}")]
    public async Task<IActionResult> DeleteWorkingTime(int workingTimeId)
    {
        await _workingTimesService.DeleteWorkingTimeAsync(workingTimeId);

        return Ok();
    }
}