using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Entities
{
    public class CartItem
    {
        private int _quantity;
        private Product _product;

        public CartItem(Product product, int quantity)
        {
            Product = product;
            _quantity = quantity;
            TotalAmount = Math.Round(product.Price * quantity, 2);
        }

        public Product Product
        {
            get
            {
                return _product;
            }
            set
            {
                _product = value;
            }
        }

        public readonly double TotalAmount;

        public int Quantity
        {
            get
            {
                return _quantity;
            }
            set
            {
                _quantity = value;
            }
        }
    }
}
