using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Entities
{
    public class Product
    {

        private int _categoryId;

        private string _title;

        private double _price;

        private int _stockQuantity;

        private string _imageURL;

        public Product(int id, string title, double price, int categoryId, int stockQuantity, string imageURL)
        {
            Id = id;
            _title = title;
            _price = price;
            _categoryId = categoryId;
            _stockQuantity = stockQuantity;
            _imageURL = imageURL;
        }

        public int somt { get; set; }

        public int Id;

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

        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
            }
        }

        public double Price
        {
            get
            {
                return _price;
            }
            set
            {
                _price = value;
            }
        }

        public int StockQuantity
        {
            get
            {
                return _stockQuantity;
            }
            set
            {
                _stockQuantity = value;
            }
        }

        public string ImageURL
        {
            get
            {
                return _imageURL;
            }
            set
            {
                _imageURL = value;
            }
        }
    }
}
