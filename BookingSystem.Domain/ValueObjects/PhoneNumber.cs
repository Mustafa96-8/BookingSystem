using BookingSystem.Domain.Common;
using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BookingSystem.Domain.ValueObjects;
public record PhoneNumber
{
    private const string rusPhoneRegex = @"^((8|\+7)[\-]?)?(\(?\d{3}\)?[\-]?)?[\d\- ]{7,10}$";

    public string Number { get; private set; }

    private PhoneNumber()
    {
    }

    public PhoneNumber(string number)
    {
        Number = number;
    }

    public static Result<PhoneNumber, Error> Create(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            return Errors.General.ValueIsRequired(nameof(PhoneNumber));
        }
        if (Regex.IsMatch(input, rusPhoneRegex) == false)
        {
            return Errors.General.ValueIsInvalid(nameof(PhoneNumber));
        }
        return new PhoneNumber(input);
    }
}
