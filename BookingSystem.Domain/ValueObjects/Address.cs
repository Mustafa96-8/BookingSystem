using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Domain.ValueObjects;
public record Address
{
    public string City { get; private set; } 

    public string Street { get; private set; }

    public string Building { get; private set; }

    public string PostalCode { get; private set; }


}
