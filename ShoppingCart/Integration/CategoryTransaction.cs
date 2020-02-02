using Newtonsoft.Json;
using ShoppingCart.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Integration
{
    public static class CategoryTransaction
    {
        public static List<Category> Categories = new List<Category>();

        public static List<Category> GetCategories()
        {
            List<Category> categories = new List<Category>();
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            using (StreamReader r = new StreamReader("Integration/SampleData.json", Encoding.GetEncoding(1254)))
            {
                string json = r.ReadToEnd();
                SampleDataClass jsonContent = JsonConvert.DeserializeObject<SampleDataClass>(json);
                categories = jsonContent.Categories;
                categories.ForEach(category =>
                {
                    if (category.ParentCategoryId != 0)
                    {
                        category.ParentCategory = categories.FirstOrDefault(parentCategory => parentCategory.Id == category.ParentCategoryId);
                    }
                });
            }
            Categories = categories;
            return categories;
        }

        public static int GetParentCategoryId(int categoryId)
        {
            if(Categories.Count() == 0)
            {
                GetCategories();
            }
            int parentCategoryId = -1;

            Category category = Categories.FirstOrDefault(entity => entity.Id == categoryId);
            if(category != null && category.ParentCategory != null)
            {
                parentCategoryId = category.ParentCategoryId;
            }

            return parentCategoryId;
        }
    }
}
