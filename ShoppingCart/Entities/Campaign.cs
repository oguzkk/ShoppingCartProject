using ShoppingCart.Integration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Entities
{
    public abstract class Campaign
    {
        private int _categoryId;

        private double _discountAmount;

        private int _minimumItemCount;

        public Campaign(int id, int categpryId, double discountAmount, int minimumItemCount)
        {
            Id = id;
            _categoryId = categpryId;
            _minimumItemCount = minimumItemCount;
            _discountAmount = discountAmount;
        }

        public readonly int Id;

        public int CategoryId
        {
            get
            {
                return _categoryId;
            }
            set
            {
                _categoryId = value;
            }
        }

        public double DiscountAmount
        {
            get
            {
                return _discountAmount;
            }
            set
            {
                _discountAmount = value;
            }
        }

        public int MinimumItemCount
        {
            get
            {
                return _minimumItemCount;
            }
            set
            {
                _minimumItemCount = value;
            }
        }


        /// <summary>
        /// Returns is campaign usable or not
        /// </summary>
        /// <param name="cart"></param>
        /// <returns></returns>
        public bool IsUsable(Cart cart)
        {
            return cart.ProductList.Where((cartItem) => cartItem.Product.CategoryId == _categoryId || CategoryTransaction.GetParentCategoryId(cartItem.Product.CategoryId) == _categoryId)
                       .Sum(cartItem => cartItem.Quantity) >= _minimumItemCount;
        }

        /// <summary>
        /// Returns the amount of total discount
        /// </summary>
        /// <param name="cart"></param>
        /// <returns></returns>
        public abstract double CalculateTotalDiscount(Cart cart);
    }
}
