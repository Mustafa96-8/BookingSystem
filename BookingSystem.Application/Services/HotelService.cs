using BookingSystem.Application.Abstractions;
using BookingSystem.Application.Abstrations;
using BookingSystem.Domain.Common;
using BookingSystem.Domain.Entities;
using BookingSystem.Domain.ValueObjects;
using Contracts.DTO;
using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Services;
public class HotelService
{
    private readonly IHotelRepository _hotelRepository;

    public HotelService(IHotelRepository hotelRepository)
    {
        _hotelRepository = hotelRepository;
    }

    public async Task<Result<IEnumerable<Hotel>,Error>> GetAll(CancellationToken ct)
    {
        return await _hotelRepository.Get(ct);
    }

    public async Task<Result<Guid,Error>> Create(HotelRequest request,CancellationToken ct)
    {
        var adress = Address.Create(
            request.Name, 
            request.Street, 
            request.Building, 
            request.PostalCode);

        if (adress.IsFailure)
            return adress.Error;
       
        var hotel = Hotel.Create(
            request.Name, 
            adress.Value, 
            request.Rating);

        if (hotel.IsFailure) 
            return hotel.Error;
        var id = await _hotelRepository.Add(hotel.Value,ct);

        if (id.IsFailure)
        {
            return id.Error;
        }

        return id.Value;

    }




}
