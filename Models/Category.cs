using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Commerce.Models
{
    public class Category
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [JsonIgnore]
        public ICollection<Product> Products { get; set; }
    }
}