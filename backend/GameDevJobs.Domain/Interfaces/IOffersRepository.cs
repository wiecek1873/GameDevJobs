using Backend.Domain.Entities;

namespace Backend.Domain.Interfaces;
public interface IOffersRepository
{
    Task<Offer?> GetOfferAsync(int id);
    Task<ICollection<Offer>?> GetOffersAsync();
    Task<Offer?> CreateOfferAsync(Offer newOffer);
    Task UpdateOfferAsync(int id, Offer updatedOffer);
    Task DeleteOfferAsync(int id);
}
