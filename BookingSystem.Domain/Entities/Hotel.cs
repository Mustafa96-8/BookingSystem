using BookingSystem.Domain.Common;
using BookingSystem.Domain.ValueObjects;
using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Domain.Entities;
public class Hotel : Entity
{
    private Hotel() {}
    private Hotel(string name,Address address,float rating):base()
    {
        Name = name;
        Address = address;
        Rating = rating;
    }

    public string Name { get; private set; } = "Unknown Hotel";

    public Address Address { get; private set; }

    public float Rating { get; private set; } = 0;

    public static Result<Hotel, Error> Create(string name, Address address, float rating)
    {
        if(name.IsNullOrWhiteSpace())
            return Errors.General.ValueIsRequired(nameof(name));
        if(rating < 0 || rating > 5)
            return Errors.General.ValueIsInvalid(nameof(rating));
        return new Hotel(name,address,rating);
    }

}
