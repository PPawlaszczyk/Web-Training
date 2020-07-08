using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
namespace PartyInvites.Models
{
    public class ShoppingCart_LINQ
    {
        private IValueCalculator calc;

        public ShoppingCart_LINQ(IValueCalculator calcParam)
        {
            calc = calcParam;
        }

        public IEnumerable<Produkt> Produkts { get; set; }
        public decimal CalculateProductTotal()
        {
            return calc.ValueProducts(Produkts);
        }

    }



}