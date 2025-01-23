using BookingSystem.Domain.Common;
using BookingSystem.Domain.ValueObjects;
using CSharpFunctionalExtensions;
using System.Globalization;

namespace BookingSystem.Domain.Entities;
public class User
{
    private User() { }
    private User(string name,string email,string passsword, PhoneNumber phone,float rating)
    {
        Name = name;
        Email = email;
        Password = passsword;
        Phone = phone;
        Rating = rating;
    }
    public Guid Id { get; init; }

    public string Name { get; private set; }

    public string Email { get; private set; }

    public string Password { get; private set; }

    public PhoneNumber Phone {  get; private set; }

    public float Rating { get; private set; } = 0;

    public static Result<User,Error> Create(string name, string email, string passsword, PhoneNumber phone, float rating)
    {
        
        return new User(name, email, passsword, phone, rating);
    }

}

