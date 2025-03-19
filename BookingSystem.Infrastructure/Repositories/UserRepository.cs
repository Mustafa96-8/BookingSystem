using BookingSystem.Domain.Common;
using BookingSystem.Domain.Entities;
using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly BookingSystemDbContext _context;

        public UserRepository(BookingSystemDbContext context)
        {
            _context = context;
        }

        public async Task<Result<int, Error>> Delete(User user, CancellationToken ct)
        {
            _context.Users.Remove(user);
            int result = await _context.SaveChangesAsync(ct);
            if(result == 0)
            {
                return new Error("db.users.remove.error", "Database user remove Error");
            }
            return result;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<Result<User, Error>> GetById(Guid id, CancellationToken ct)
        {
            var result = await _context.Users.FirstOrDefaultAsync(u => u.Id == id, ct);
            if(result == null)
            {
                return new Error("db.users.find.byid.error", "Database find user by Id Error");
            }
            return result;
        }

        public async Task<Result<IEnumerable<User>, Error>> Get(CancellationToken ct)
        {
            var result = await _context.Users.ToListAsync(ct);
            if(result == null)
            {
                return new Error("db.users.find.all.error", "Database find all users Error");
            }
            return result;
        }

        public async Task<Result<Guid, Error>> Update(User user, CancellationToken ct)
        {
            _context.Users.Update(user);
            var result = await _context.SaveChangesAsync(ct);
            if(result == 0)
            {
                return new Error("db.users.update.error", "Database update User Error");
            }
            return user.Id;
        }

        public async Task<Result<Guid, Error>> Add(User user, CancellationToken ct)
        {
            _context.Users.Add(user);
            var result = await _context.SaveChangesAsync(ct);
            if(result == 0)
            {
                return new Error("db.users.add.error", "Database add User Error");
            }
            return user.Id;
        }
    }
}
