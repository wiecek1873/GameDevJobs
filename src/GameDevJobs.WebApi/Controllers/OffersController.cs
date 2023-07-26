using Backend.Application.Dto.Offers;
using Backend.Application.Interfaces.Services;
using Backend.WebApi.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Controllers;
[ApiController]
[GlobalExceptionFilter]
[Route("api/[controller]")]
public class OffersController : ControllerBase
{
    private readonly IOffersService _offersService;

    public OffersController(IOffersService offersService)
    {
        _offersService = offersService;
    }

    [HttpGet]
    public async Task<IActionResult> GetOffers()
    {
        var offers = await _offersService.GetOffersAsync();

        return Ok(offers);
    }

    [HttpGet("{offerId}")]
    public async Task<IActionResult> GetOffer(int offerId)
    {
        var offer = await _offersService.GetOfferAsync(offerId);

        return Ok(offer);
    }

    [HttpPost]
    public async Task<IActionResult> CreateOffer([FromBody] RequestOfferDto requestOfferDto)
    {
        var newOffer = await _offersService.CreateOfferAsync(requestOfferDto);

        return Created($"api/offers/{newOffer.Id}", newOffer);
    }

    [HttpPut("{offerId}")]
    public async Task<IActionResult> UpdateOffer([FromRoute] int offerId, [FromBody] RequestOfferDto requestOfferDto)
    {
        await _offersService.UpdateOfferAsync(offerId, requestOfferDto);

        return NoContent();
    }

    [HttpDelete("{offerId}")]
    public async Task<IActionResult> DeleteOffer(int offerId)
    {
        await _offersService.DeleteOfferAsync(offerId);

        return Ok();
    }
}
