using ShoppingCart.Entities;
using System;
using Xunit;

namespace ShoppingCartXUnitTestProject
{
    public class CartTests
    {
        [Fact]
        public void IsCouponAppliedTest()
        {
            RateCoupon rateCoupon = new RateCoupon("RateTest", 150, 50);
            Cart cart = new Cart();
            Product product = new Product(3, "testProduct", 100, 5, 99, "");
            cart.AddItem(product, 2);
            Assert.False(cart.IsCouponApplied);
            cart.ApplyCoupon(rateCoupon);
            Assert.True(cart.IsCouponApplied);
        }

        [Fact]
        public void AddItemTest()
        {
            RateCoupon rateCoupon = new RateCoupon("RateTest", 150, 50);
            Cart cart = new Cart();
            Product product = new Product(3, "testProduct", 100, 5, 99, "");
            cart.AddItem(product, 2);
            Assert.Equal(cart.ProductList[0].Product, product);
        }

        [Fact]
        public void GetTotalAmountTest()
        {
            AmountCoupon rateCoupon = new AmountCoupon("AmountTest", 150, 77);
            Cart cart = new Cart();
            Product product = new Product(3, "testProduct", 100, 5, 99, "");
            cart.AddItem(product, 2);
            double totalAmount = cart.GetTotalAmount();
            Assert.Equal(200, totalAmount);
        }
    }
}
