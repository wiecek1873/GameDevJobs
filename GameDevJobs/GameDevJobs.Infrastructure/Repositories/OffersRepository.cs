using GameDevJobs.Data;
using GameDevJobs.Domain.Entities;
using GameDevJobs.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GameDevJobs.Infrastructure.Repositories;

public class OffersRepository : IOffersRepository
{
    private readonly GameDevJobsContext _gameDevJobsContext;

    public OffersRepository(GameDevJobsContext gameDevJobsContext)
    {
        _gameDevJobsContext = gameDevJobsContext;
    }

    public async Task<ICollection<Offer>?> GetOffersAsync()
    {
        return await _gameDevJobsContext.Offers.ToListAsync();
    }

    public async Task<Offer?> GetOfferAsync(int id)
    {
        return await _gameDevJobsContext.Offers.SingleOrDefaultAsync(o => o.Id == id);
    }

    public async Task<Offer?> CreateOfferAsync(Offer newOffer)
    {
        await _gameDevJobsContext.Offers.AddAsync(newOffer);
        await _gameDevJobsContext.SaveChangesAsync();

        return newOffer;
    }

    public async Task UpdateOfferAsync(int id, Offer updatedOffer)
    {
        var offerToUpdate = await _gameDevJobsContext.Offers.SingleOrDefaultAsync(o => o.Id == id);

        if (offerToUpdate == null)
            return;

        offerToUpdate.Title = updatedOffer.Title;
        offerToUpdate.CompanyId = updatedOffer.CompanyId;
        offerToUpdate.LocationId = updatedOffer.LocationId;
        offerToUpdate.CategoryId = updatedOffer.CategoryId;
        offerToUpdate.WorkingTimeId = updatedOffer.WorkingTimeId;
        offerToUpdate.SeniorityId = updatedOffer.SeniorityId;
        offerToUpdate.SalaryMin = updatedOffer.SalaryMin;
        offerToUpdate.SalaryMax = updatedOffer.SalaryMax;
        updatedOffer.Date = updatedOffer.Date;
        updatedOffer.Views = updatedOffer.Views;
        updatedOffer.Url = updatedOffer.Url;

        await _gameDevJobsContext.SaveChangesAsync();
    }

    public async Task DeleteOfferAsync(int id)
    {
        var offerToDelete = await _gameDevJobsContext.Offers.SingleOrDefaultAsync(o => o.Id ==id);

        if (offerToDelete == null)
            return;

        _gameDevJobsContext.Remove(offerToDelete);
        await _gameDevJobsContext.SaveChangesAsync();
    }
}
