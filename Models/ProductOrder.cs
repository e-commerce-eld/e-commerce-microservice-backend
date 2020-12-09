using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace Commerce.Models
{
    public class ProductOrder
    {
        public int ProductId { get; set; }
        public int OrderId { get; set; }

        [JsonIgnore]
        public Product Product { get; set; }
        public Order Order { get; set; }
    }
}
