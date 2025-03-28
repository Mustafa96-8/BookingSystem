﻿using BookingSystem.Application.Abstractions;
using BookingSystem.Application.Services;
using BookingSystem.Domain.Entities;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application;
public static class DependencyRegistration
{
    public static IServiceCollection AddApplication(this IServiceCollection services) 
    {
        services.AddScoped<HotelService>();
        services.AddScoped<UserService>();
        services.AddValidatorsFromAssembly(typeof(DependencyRegistration).Assembly);
        return services;
    }
}
