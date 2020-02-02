using ShoppingCart.Entities;
using ShoppingCart.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ShoppingCartXUnitTestProject
{
    public class CampaignTests
    {
        [Fact]
        public void CantUseCampaign_If_TotalAmount_Less_Than_CouponMinimumAmount()
        {
            RateCampaign rateCampaign = new RateCampaign(1, 5, 150, 3);
            Cart cart = new Cart();
            bool result = rateCampaign.IsUsable(cart);
            Assert.False(result);
        }

        [Fact]
        public void UseRateCampaign()
        {
            Cart cart = new Cart();
            Product product = new Product(3, "testProduct", 100, 22, 99, "");
            cart.AddItem(product, 2);
            cart.ApplyDiscounts();
            double totalAmountAfterDiscounts = cart.GetTotalAmountAfterDiscounts();
            Assert.Equal(160, totalAmountAfterDiscounts);
            double totalCampaignDiscount = cart.GetCampaignDiscount();
            Assert.Equal(40, totalCampaignDiscount);
        }

        [Fact]
        public void UseAmountCampaign()
        {
            Cart cart = new Cart();
            Product product = new Product(3, "testProduct", 100, 33, 99, "");
            cart.AddItem(product, 10);
            cart.ApplyDiscounts();
            double totalAmountAfterDiscounts = cart.GetTotalAmountAfterDiscounts();
            Assert.Equal(995, totalAmountAfterDiscounts);
            double totalCampaignDiscount = cart.GetCampaignDiscount();
            Assert.Equal(5, totalCampaignDiscount);
        }
    }
}
