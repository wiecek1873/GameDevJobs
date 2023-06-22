using AutoMapper;
using GameDevJobs.Application.Dto.Offers;
using GameDevJobs.Application.Exceptions;
using GameDevJobs.Application.Interfaces;
using GameDevJobs.Domain.Entities;
using GameDevJobs.Domain.Interfaces;

namespace GameDevJobs.Application.Services;

public class OffersService : IOffersService
{
    private const string NOT_FOUND_MESSAGE = "Offer with this id does not exist.";

    private readonly IOffersRepository _offersRepository;
    private readonly IMapper _mapper;

    public OffersService(IOffersRepository offersRepository, IMapper mapper)
    {
        _offersRepository = offersRepository;
        _mapper = mapper;
    }

    public async Task<ICollection<OfferDto>> GetOffersAsync()
    {
        var offers = await _offersRepository.GetOffersAsync() ;

        return _mapper.Map<ICollection<OfferDto>>(offers);
    }

    public async Task<OfferDto> GetOfferAsync(int id)
    {
        var offer = await _offersRepository.GetOfferAsync(id);

        if (offer == null)
            throw new NotFoundException(NOT_FOUND_MESSAGE);

        return _mapper.Map<OfferDto>(offer);
    }

    public async Task<OfferDto> CreateOfferAsync(RequestOfferDto requestOfferDto)
    {
        var offerToCreate = _mapper.Map<Offer>(requestOfferDto);

        var createdOffer = await _offersRepository.CreateOfferAsync(offerToCreate);

        return _mapper.Map<OfferDto>(createdOffer);
    }

    public async Task UpdateOfferAsync(int id, RequestOfferDto requestOfferDto)
    {
        var offerToUpdate = await _offersRepository.GetOfferAsync(id);

        if(offerToUpdate == null)
            throw new NotFoundException(NOT_FOUND_MESSAGE);

        var updatedOffer = _mapper.Map<Offer>(requestOfferDto);
        await _offersRepository.UpdateOfferAsync(id, updatedOffer);
    }

    public async Task DeleteOfferAsync(int id)
    {
        var offerToUpdate = await _offersRepository.GetOfferAsync(id);

        if (offerToUpdate == null)
            throw new NotFoundException(NOT_FOUND_MESSAGE);

        await _offersRepository.DeleteOfferAsync(id);
    }
}
