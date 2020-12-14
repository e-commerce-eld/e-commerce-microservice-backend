using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Commerce.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }

        public int CategoryId { get; set; }
        [JsonIgnore]

        public ICollection<ProductOrder> ProductOrders { get; set; }
     

    }
}