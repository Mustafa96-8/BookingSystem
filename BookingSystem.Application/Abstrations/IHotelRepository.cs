using BookingSystem.Application.Abstractions;
using BookingSystem.Domain.Common;
using BookingSystem.Domain.Entities;
using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;                 
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Abstractions;
public interface IHotelRepository : IGenericRepository<Hotel>
{

}
