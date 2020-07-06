using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
namespace PartyInvites.Models
{
    public class ShoppingCart
    {
        public List < Produkt> Products { get; set; }
    }

    public class ShoppingCart_enum : IEnumerable<Produkt>
    {
        public List<Produkt> Products { get; set; }
        public IEnumerator<Produkt> GetEnumerator()
        {
            return Products.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

}