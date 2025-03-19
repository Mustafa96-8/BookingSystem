using BookingSystem.Application.Abstractions;
using BookingSystem.Domain.Common;
using BookingSystem.Domain.Entities;
using CSharpFunctionalExtensions;

namespace BookingSystem.Infrastructure.Repositories;
public interface IUserRepository :IGenericRepository<User>
{
}