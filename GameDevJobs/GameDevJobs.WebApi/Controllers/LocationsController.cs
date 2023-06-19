using GameDevJobs.Application.Dto.Locations;
using GameDevJobs.Application.Interfaces;
using GameDevJobs.WebApi.Filters;
using Microsoft.AspNetCore.Mvc;

namespace GameDevJobs.WebApi.Controllers;

[ApiController]
[GlobalExceptionFilter]
[Route("api/[controller]")]
public class LocationsController : ControllerBase
{
    private readonly ILocationsService _locationsService;

    public LocationsController(ILocationsService locationsService)
    {
        _locationsService = locationsService;
    }

    [HttpGet]
    public async Task<IActionResult> GetLocations()
    {
        var locations = await _locationsService.GetLocationsAsync();

        return Ok(locations);
    }

    [HttpGet("{locationId}")]
    public async Task<IActionResult> GetLocation(int locationId)
    {
        var location = await _locationsService.GetLocationAsync(locationId);

        return Ok(location);
    }

    [HttpPost]
    public async Task<IActionResult> CreateLocation([FromBody] RequestLocationDto requestLocationDto)
    {
        var newLocation = await _locationsService.CreateLocationAsync(requestLocationDto);

        return Created($"api/locations/{newLocation.Id}", newLocation);
    }

    [HttpPut("{locationId}")]
    public async Task<IActionResult> UpdateLocation([FromRoute] int locationId, [FromBody] RequestLocationDto requestLocationDto)
    {
        await _locationsService.UpdateLocationAsync(locationId, requestLocationDto);

        return NoContent();
    }

    [HttpDelete("{locationId}")]
    public async Task<IActionResult> DeleteLocation(int locationId)
    {
        await _locationsService.DeleteLocationAsync(locationId);

        return Ok();
    }
}
