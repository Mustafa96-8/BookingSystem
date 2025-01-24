using BookingSystem.Domain.Common;
using BookingSystem.Domain.Entities;
using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Abstractions;
public interface IHotelRepository : IDisposable
{
    Task<Result<int, Error>> DeleteHotel(Hotel hotel);
    Task<Result<Hotel, Error>> GetHotelById(Guid id);
    Task<Result<IEnumerable<Hotel>, Error>> GetHotels();
    Task<Result<int, Error>> UpdateHotel(Hotel hotel);

}
