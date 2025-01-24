using BookingSystem.Application.;
using BookingSystem.Application.Abstractions;
using BookingSystem.Domain.Common;
using BookingSystem.Domain.Entities;
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
        return await _hotelRepository.GetHotels();
    }




}
