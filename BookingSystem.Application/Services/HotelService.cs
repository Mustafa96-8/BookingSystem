using BookingSystem.Application.Abstractions;
using BookingSystem.Domain.Common;
using BookingSystem.Domain.Entities;
using BookingSystem.Domain.ValueObjects;
using Contracts.DTO;
using CSharpFunctionalExtensions;

namespace BookingSystem.Application.Services;
public class HotelService
{
    private readonly IHotelRepository _hotelRepository;

    public HotelService(IHotelRepository hotelRepository)
    {
        _hotelRepository = hotelRepository;
    }

    public async Task<Result<IEnumerable<Hotel>, Error>> GetAll(CancellationToken ct)
    {
        var hotels = await _hotelRepository.Get(ct);
        if(hotels.IsFailure)
            return hotels.Error;
        return hotels.Value.ToList();
    }

    public async Task<Result<Hotel, Error>> GetById(Guid? id, CancellationToken ct)
    {
        if(id == null) return Errors.General.ValueIsRequired(nameof(id));
        var hotel = await _hotelRepository.GetById((Guid)id, ct);
        if(hotel.IsFailure)
            return hotel.Error;
        return hotel.Value;
    }

    public async Task<Result<Guid, Error>> Create(HotelRequest request, CancellationToken ct)
    {
        var adress = Address.Create(
            request.City,
            request.Street,
            request.Building,
            request.PostalCode);

        if(adress.IsFailure)
            return adress.Error;

        var hotel = Hotel.Create(
            request.Name,
            adress.Value,
            request.Rating);

        if(hotel.IsFailure)
            return hotel.Error;
        var id = await _hotelRepository.Add(hotel.Value, ct);

        if(id.IsFailure)
        {
            return id.Error;
        }

        return id.Value;
    }




}
