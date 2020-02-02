using ShoppingCart.Entities;
using ShoppingCart.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ShoppingCartXUnitTestProject
{
    public class DeliveryCostTests
    {
        [Fact]
        public void DeliveryCost_MustBeEqualTo_FixedCost()
        {
            Cart cart = new Cart();
            double result = cart.GetDeliveryCost();
            Assert.Equal(Constants.FixedCost, result);
        }

        [Fact]
        public void DeliveryCostTest()
        {
            Cart cart = new Cart();
            Product testProduct1 = new Product(6, "testProduct1", 22, 33, 1, "");
            Product testProduct2 = new Product(2, "testProduct2", 22, 34, 1, "");
            cart.AddItem(testProduct1, 2);
            cart.AddItem(testProduct2, 3);
            double result = cart.GetDeliveryCost();
            Assert.Equal(5.97, result);
        }

        [Fact]
        public void DeliveryCostTest_SameCategory()
        {
            Cart cart = new Cart();
            Product testProduct1 = new Product(6,"testProduct1", 22, 33, 1, "");
            Product testProduct2 = new Product(2, "testProduct2", 22, 33, 1, "");
            cart.AddItem(testProduct1, 2);
            cart.AddItem(testProduct2, 3);
            double result = cart.GetDeliveryCost();
            Assert.Equal(4.98, result);
        }

        [Fact]
        public void DeliveryCostTest_DiffrentCategory()
        {
            Cart cart = new Cart();
            Product testProduct1 = new Product(6, "testProduct1", 22, 33, 1, "");
            Product testProduct2 = new Product(6, "testProduct2", 22, 34, 1, "");
            cart.AddItem(testProduct1, 2);
            cart.AddItem(testProduct2, 3);
            double result = cart.GetDeliveryCost();
            Assert.Equal(4.48, result);
        }
    }
}
