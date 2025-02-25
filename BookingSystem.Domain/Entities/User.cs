using BookingSystem.Domain.Common;
using BookingSystem.Domain.ValueObjects;
using CSharpFunctionalExtensions;
using System.Globalization;

namespace BookingSystem.Domain.Entities;
public class User : Entity
{
    private User() { }
    private User(string name,string email,string passsword, PhoneNumber phone)
    {
        Name = name;
        Email = email;
        Password = passsword;
        Phone = phone;
    }
    /// <summary>
    /// Full Name of User
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    /// 
    /// </summary>
    public string Email { get; private set; }

    public string? PasswordHash { get; private set; }

    private string Salt { get; set; }
    /// <summary>
    /// Номер телефона 
    /// </summary>
    public PhoneNumber Phone {  get; private set; }

    /// <summary>
    /// TO DO: Добавить Валидацию
    /// </summary>
    public static Result<User,Error> Create(string name, string email, string passsword, PhoneNumber phone)
    {
        
        return new User(name, email, passsword, phone);
    }

}

