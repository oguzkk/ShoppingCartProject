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
    public static class ProductTransaction
    {
        public static List<Product> GetProducts()
        {
            List<Product> products = new List<Product>();
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            using (StreamReader r = new StreamReader("Integration/SampleData.json", Encoding.GetEncoding(1254)))
            {
                string json = r.ReadToEnd();
                SampleDataClass jsonContent = JsonConvert.DeserializeObject<SampleDataClass>(json);
                products = jsonContent.Products;
            }
            return products;
        }
    }
}
