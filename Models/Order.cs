using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Commerce.Models

{
    public class Order
    {
        public int OrderId {get;set;}
        public string Description{get;set;}
        public float Value{get;set;}
        public string Address{get;set;}

        public int ClientId { get; set; }

        
        [JsonIgnore]
        public Client Client {get;set;}
        [JsonIgnore]
        public ICollection<Product> Products { get; set; }
        [JsonIgnore]
        public ICollection<ProductOrder> ProductOrders { get; set; }


    }
}