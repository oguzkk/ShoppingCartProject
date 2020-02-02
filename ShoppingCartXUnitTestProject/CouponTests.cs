using ShoppingCart.Entities;
using System;
using Xunit;

namespace ShoppingCartXUnitTestProject
{
    public class CouponTests
    {
        [Fact]
        public void CantUseCoupon_If_TotalAmount_Less_Than_CouponMinimumAmount()
        {
            RateCoupon rateCoupon = new RateCoupon("CanUseTest", 150, 50);
            Cart cart = new Cart();
            bool result = cart.ApplyCoupon(rateCoupon);
            Assert.False(result);
        }

        [Fact]
        public void UseRateCoupon()
        {
            RateCoupon rateCoupon = new RateCoupon("RateTest", 150, 50);
            Cart cart = new Cart();
            Product product = new Product(3, "testProduct", 100, 5, 99, "");
            cart.AddItem(product, 2);
            bool result = cart.ApplyCoupon(rateCoupon);
            Assert.True(result);
            double totalAmountAfterDiscounts = cart.GetTotalAmountAfterDiscounts();
            Assert.Equal(100, totalAmountAfterDiscounts);
            double totalCouponDiscount = cart.GetCouponDiscount();
            Assert.Equal(100, totalCouponDiscount);
        }

        [Fact]
        public void UseAmountCoupon()
        {
            AmountCoupon rateCoupon = new AmountCoupon("AmountTest", 150, 77);
            Cart cart = new Cart();
            Product product = new Product(3, "testProduct", 100, 5, 99, "");
            cart.AddItem(product, 2);
            bool result = cart.ApplyCoupon(rateCoupon);
            Assert.True(result);
            double totalAmountAfterDiscounts = cart.GetTotalAmountAfterDiscounts();
            Assert.Equal(123, totalAmountAfterDiscounts);
            double totalCouponDiscount = cart.GetCouponDiscount();
            Assert.Equal(77, totalCouponDiscount);
        }
    }
}
