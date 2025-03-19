using BookingSystem.Domain.Common;
using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Domain.ValueObjects;
public record Address
{
    const int MAXPROPERTYLENGTH = 100;
    public string City { get; private set; } 

    public string Street { get; private set; }

    public string Building { get; private set; }

    public string PostalCode { get; private set; }

    private Address(string city,string street,string building,string postalCode)
    {
        City = city;
        Street = street;
        Building = building;
        PostalCode = postalCode;
    }

    public static Result<Address,Error> Create(string city, string street, string building, string postalCode)
    {
        city = city.Trim();
        street = street.Trim();
        building = building.Trim();
        postalCode = postalCode.Trim();
        if(city.Length is < 1 or > MAXPROPERTYLENGTH)
            return Errors.General.InvalidLength("city");
        if(street.Length is < 1 or > MAXPROPERTYLENGTH)
            return Errors.General.InvalidLength("street");
        if(building.Length is < 1 or > MAXPROPERTYLENGTH)
            return Errors.General.InvalidLength("building");
        if(postalCode.Length is < 1 or > MAXPROPERTYLENGTH)
            return Errors.General.InvalidLength("postalCode");

        return new Address(city, street, building, postalCode);
    }


}
