using BookingSystem.Application.Abstractions;
using BookingSystem.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Infrastructure;
public static class DependencyRegistration
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IHotelRepository,HotelRepository>();
        services.AddScoped<IUserRepository,UserRepository>();
        services.AddDbContext<BookingSystemDbContext>();

        return services;
    }
}
