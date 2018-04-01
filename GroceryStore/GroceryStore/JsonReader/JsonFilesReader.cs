using DTO;
using Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace Json.Reader
{
    public class JsonFilesReader
    {
        public IList<Product> Read(string fileLocation = "C:/Users/Jivka/Desktop/products.json")
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore,
                Formatting = Formatting.None,
                DateFormatHandling = DateFormatHandling.IsoDateFormat,
                Converters = new List<JsonConverter> { new DecimalConverter() }
            };

            var json = File.ReadAllText(fileLocation);
            //var products = JsonConvert.DeserializeObject<List<ProductModel>>(json);  // TODO use DTO objects
            var products = JsonConvert.DeserializeObject<List<Product>>(json);

            return products;
        }
    }
}
