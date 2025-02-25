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
    /// <summary>
    /// TO DO: Добавить Валидацию
    /// </summary>
    public static Result<Hotel,Error> Create(string name,Address address,float rating)
    {

        return new Hotel(name,address,rating);
    }

}
