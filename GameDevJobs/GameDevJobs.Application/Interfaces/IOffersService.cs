using GameDevJobs.Application.Dto.Offers;

namespace GameDevJobs.Application.Interfaces;

public interface IOffersService
{
    Task<ICollection<OfferDto>> GetOffersAsync();
    Task<OfferDto> GetOfferAsync(int id);
    Task<OfferDto> CreateOfferAsync(RequestOfferDto requestOfferDto);
    Task UpdateOfferAsync(int id, RequestOfferDto requestOfferDto);
    Task DeleteOfferAsync(int id);
}
