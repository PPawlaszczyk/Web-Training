using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PartyInvites.Models
{
    public interface IValueCalculator
    {
        decimal ValueProducts(IEnumerable<Produkt> produkts);
    }
}
