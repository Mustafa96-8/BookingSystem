using BookingSystem.Domain.Common;
using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Domain.ValueObjects;

public record Price
{
    public Price(double value,string currency)
    {
        this.value = value;
        this.currency = currency;
    }
    public double value { get; private set; }
    public string currency { get; private set; }

    //TO DO Добавить валидацию
    public static Result<Price,Error> Create(double value,string currency)
    {
        return new Price(value, currency);
    }
}
