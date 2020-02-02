using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Entities
{
    public class Category
    {
        private string _title;

        private int _parentCategoryId;

        private Category _parentCategory;

        public Category(int id, string title, int parentCategoryId)
        {
            Id = id;
            _title = title;
            _parentCategoryId = parentCategoryId;
        }

        public readonly int Id;

        public Category ParentCategory
        {
            get
            {
                return _parentCategory;
            }
            set
            {
                _parentCategory = value;
            }
        }

        public int ParentCategoryId
        {
            get
            {
                return _parentCategoryId;
            }
            set
            {
                _parentCategoryId = value;
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
    }
}
