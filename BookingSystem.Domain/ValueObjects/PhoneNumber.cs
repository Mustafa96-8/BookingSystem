using BookingSystem.Domain.Common;
using CSharpFunctionalExtensions;
using PN = PhoneNumbers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BookingSystem.Domain.ValueObjects;
public record PhoneNumber
{
    public string Number { get; private set; }


    private PhoneNumber(string number)
    {
        Number = number;
    }

    public static Result<PhoneNumber, Error> Create(string input)
    {
        input = input.Trim(); 
        if (input.Length is <1 or >11)
        {
            return Errors.General.ValueIsRequired("PhoneNumberRecord");
        }
        if (ValidatePhoneNumber(input))
        {
            return Errors.General.ValueIsInvalid("PhoneNumberRecord");
        }
        return new PhoneNumber(input);
    }

    private static bool ValidatePhoneNumber(string phoneNumber)
    {
        PN.PhoneNumberUtil phoneNumberUtil = PN.PhoneNumberUtil.GetInstance();
        try
        {
            PN.PhoneNumber parsedPhoneNumber = phoneNumberUtil.Parse(phoneNumber, null);
            return phoneNumberUtil.IsValidNumber(parsedPhoneNumber);
        }
        catch(PN.NumberParseException)
        {
            return false;
        }
    }
}
