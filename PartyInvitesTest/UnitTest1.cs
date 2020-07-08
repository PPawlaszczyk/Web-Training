using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PartyInvites.Models;
namespace PartyInvitesTest
{
    [TestClass]
    public class UnitTest1
    {
        private IDiscountHelper getTestObject()
        {
            return new MinimumDiscountHelper();
        }
        [TestMethod]
        public void Dicount_Above_100()
        {
            //arange
            IDiscountHelper target = getTestObject();
            decimal total = 200;
            //act
            var discountedTotal = target.ApplyDiscount(total);
            //assert
            Assert.AreEqual(total*0.9M, discountedTotal);
        }
        [TestMethod]
        public void Dicount_Beetwen_10_And_100()
        {
            //arange
            IDiscountHelper target = getTestObject();
            //act
            decimal TenDollarDiscount = target.ApplyDiscount(10);
            decimal HundredDollarDiscount = target.ApplyDiscount(100);
            decimal FiftyDollarSicount = target.ApplyDiscount(50);

            //assert
            Assert.AreEqual(5, TenDollarDiscount, "rabat w wysokosci 10zl jest nieprawdilowy");
            Assert.AreEqual(95, HundredDollarDiscount, "rabat w wysokosci 10zl jest nieprawdilowy");
            Assert.AreEqual(45, FiftyDollarSicount, "rabat w wysokosci 10zl jest nieprawdilowy");

        }
        [TestMethod]
        public void Dicount_Less_Than_100()
        {
            //arange
            IDiscountHelper target = getTestObject();
            //act
            decimal discount5 = target.ApplyDiscount(5);
            decimal discount0 = target.ApplyDiscount(0);

            //assert
            Assert.AreEqual(5, discount5);
            Assert.AreEqual(0, discount0);

        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Dicount_Negative_Total()
        {
            //arange
            IDiscountHelper target = getTestObject();
            //act
          
            target.ApplyDiscount(-1);

        }
    }
}
