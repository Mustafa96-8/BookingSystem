using BookingSystem.Domain.ValueObjects;
using Contracts.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Validators;

public class HotelRequestValidator : AbstractValidator<HotelRequest>
{
    public HotelRequestValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MinimumLength(1).MaximumLength(80);
        RuleFor(x => new { x.City, x.Street, x.Building, x.PostalCode })
            .MustBeValueObject(u => Address.Create(u.City, u.Street, u.Building, u.PostalCode));

        RuleFor(x => x.Rating).NotNull().Must(x => x is <= 5 and >= 0);
    }
}
