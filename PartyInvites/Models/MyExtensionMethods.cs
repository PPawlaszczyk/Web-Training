using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
namespace PartyInvites.Models
{
    public static class MyExtensionMethods
    {
       public static decimal TotalPrices(this ShoppingCart cartParm)
        {

            decimal total = 0;
            foreach(Produkt prod in cartParm.Products)
            {
                total += prod.Price;
            }
            return total;
        }

        public static decimal TotalPrices_enum(this IEnumerable<Produkt> productEnum)
        {

            decimal total = 0;
            foreach (Produkt prod in productEnum)
            {
                total += prod.Price;
            }
            return total;
        }
        public static IEnumerable<Produkt> FilterByCategory(this IEnumerable<Produkt> productEnum, string categoryParam)
        {
            foreach (Produkt prod in productEnum)
            {
                if (prod.Category == categoryParam)
                {
                    yield return prod;
                }
            }
        }

        ///LINQ
        public static IEnumerable<Produkt> Filter_Lamda(this IEnumerable<Produkt> productEnum, Func<Produkt,bool> selectorParam)
        {
            foreach (Produkt prod in productEnum)
            {
                if (selectorParam(prod))
                {
                    yield return prod;
                }
            }
        }

    }
}