using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.DTO;
public class HotelRequest
{
    public string Name { get; set; } 

    public float Rating { get; set; }

    public string City { get;  set; }

    public string Street { get; set; }

    public string Building { get; set; }
                                                            
    public string PostalCode { get; set; }

}
