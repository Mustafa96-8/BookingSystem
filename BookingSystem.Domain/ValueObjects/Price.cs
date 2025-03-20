using BookingSystem.Domain.Common;
using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Domain.ValueObjects;
public record Price
{
    public string Currency { get; private set; }
    public double Value { get; private set; }

    private Price(double value,string currency)
    {
        Value = value;
        Currency = currency;
    }

    public static Result<Price,Error> Create(double value,string currency)
    {
        currency = currency.Trim();
        if(value < 0 )
            return Errors.General.ValueIsInvalid(nameof(value));
        if(currency.Length is <1 or >100)
            return Errors.General.ValueIsRequired(nameof(currency));
        return new Price(value, currency);
    }
}
