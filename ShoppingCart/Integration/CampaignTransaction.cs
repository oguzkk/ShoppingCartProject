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
    public static class CampaignTransaction
    {
        public static List<Campaign> GetCampaigns()
        {
            List<Campaign> campaigns = new List<Campaign>();
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            
            using (StreamReader r = new StreamReader("Integration/SampleData.json", Encoding.GetEncoding(1254)))
            {
                string json = r.ReadToEnd();
                SampleDataClass jsonContent = JsonConvert.DeserializeObject<SampleDataClass>(json);
                campaigns.AddRange(jsonContent.AmountCampaigns);
                campaigns.AddRange(jsonContent.RateCampaigns);
            }
            return campaigns;
        }
    }
}
