﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace PartyInvites.Models
{
    public class LinqValueCalculator : IValueCalculator
    {
        private IDiscountHelper discounter;
        public LinqValueCalculator(IDiscountHelper discountParam)
        {
            discounter = discountParam;
        }
        public decimal ValueProducts(IEnumerable<Produkt> produkts)
        {
            return discounter.ApplyDiscount(produkts.Sum(p => p.Price));
        }
    }
}