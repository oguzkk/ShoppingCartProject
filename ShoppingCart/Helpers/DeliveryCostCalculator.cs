using ShoppingCart.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Helpers
{
    public class DeliveryCostCalculator
    {
        private double _costPerDelivery;

        private double _costPerProduct;

        private double _fixedCost;

        public DeliveryCostCalculator(double costPerDelivery, double costPerProduct, double fixedCost = Constants.FixedCost)
        {
            _costPerDelivery = costPerDelivery;
            _costPerProduct = costPerProduct;
            _fixedCost = fixedCost;
        }

        /// <summary>
        /// Returns the total amount of delivery cost.
        /// </summary>
        /// <param name="cart"></param>
        /// <returns></returns>
        public double CalculateFor(Cart cart)
        {
            int numberOfDeliveries = CalculateNumberOfDeliveries(cart);
            int numberOfProducts = CalculateNumberOfProducts(cart);
            return Math.Round((_costPerDelivery * numberOfDeliveries) + (_costPerProduct * numberOfProducts) + _fixedCost, 2);
        }

        /// <summary>
        /// Number Of Deliveries is calculated by the number of distinct categories in the cart.
        /// </summary>
        /// <param name="cart"></param>
        /// <returns></returns>
        private int CalculateNumberOfDeliveries(Cart cart)
        {
            return cart.ProductList.Select(cartItem => cartItem.Product.CategoryId).Distinct().Count();
        }

        /// <summary>
        /// Number Of Products is the number of diffrent products in the cart.
        /// </summary>
        /// <param name="cart"></param>
        /// <returns></returns>
        private int CalculateNumberOfProducts(Cart cart)
        {
            return cart.ProductList.Count();
        }
    }
}
