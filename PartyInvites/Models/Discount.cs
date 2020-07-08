using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PartyInvites.Models
{
        public interface IDiscountHelper
        {
            decimal ApplyDiscount(decimal  totalParam);
        }
    public class DefaultDiscountHelper : IDiscountHelper
    {
        private decimal discountSize;
        public DefaultDiscountHelper(decimal discountParam)
        {
            discountSize = discountParam;

        }
        public decimal ApplyDiscount(decimal TotalParam)
        {
            return (TotalParam - (discountSize / 100m * TotalParam));
        }
    }

}