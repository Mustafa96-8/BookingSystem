using BookingSystem.Domain.Common;
using BookingSystem.Domain.Entities;
using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Abstractions;
public interface IGenericRepository<T>:IDisposable where T : class
{
    Task<Result<int, Error>> Delete(T T, CancellationToken ct);
    Task<Result<T, Error>> GetById(Guid id, CancellationToken ct);
    Task<Result<IEnumerable<T>, Error>> Get(CancellationToken ct);
    Task<Result<Guid, Error>> Update(T T, CancellationToken ct);
    Task<Result<Guid, Error>> Add(T T, CancellationToken ct);
}
