using BookingSystem.Application.Abstractions;
using BookingSystem.Application.Services;
using BookingSystem.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application;
public static class DependencyRegitration
{
    public static IServiceCollection AddApplication(this IServiceCollection services) 
    {
        services.AddScoped<HotelService>();
        return services;
    }
}
