using BookingSystem.Application.Abstractions;
using BookingSystem.Domain.Common;
using BookingSystem.Domain.Entities;
using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;

namespace BookingSystem.Infrastructure.Repositories;

public class HotelRepository : IHotelRepository
{
    private readonly BookingSystemDbContext _context;

    public HotelRepository(BookingSystemDbContext context)
    {
        _context = context;
    }

    public async Task<Result<int, Error>> DeleteHotel(Hotel hotel)
    {
        _context.Hotels.Remove(hotel);
        int result = await _context.SaveChangesAsync();
        if (result == 0)
        {
            return new Error("db.hotels.remove.error", "Database Hotel remove Error");
        }
        return result;
    }

    public void Dispose()
    {

    }

    public async Task<Result<Hotel, Error>> GetHotelById(Guid id)
    {
        var result = await _context.Hotels.FirstOrDefaultAsync(u => u.Id == id);
        if (result == null)
        {
            return new Error("db.hotels.find.byid.error", "Database find hotel by Id Error");
        }
        return result;
    }

    public async Task<Result<IEnumerable<Hotel>, Error>> GetHotels(CancellationToken ct)
    {
        var result = await _context.Hotels.ToListAsync(ct);
        if (result == null)
        {
            return new Error("db.hotels.find.all.error", "Database find all hotels Error");
        }
        return result;
    }

    public async Task<Result<int, Error>> UpdateHotel(Hotel hotel)
    {
        _context.Hotels.Update(hotel);
        var result = await _context.SaveChangesAsync();
        if (result == 0)
        {
            return new Error("db.hotels.update.error", "Database update Hotel Error");
        }
        return result;
    }
}
