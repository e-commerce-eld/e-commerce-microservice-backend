using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Commerce.Models

{
    public class Order
    {
        [Key] public int OrderId { get; set; }
        [Required] public int OrderNumber { get; set; }
        [Required] public DateTime OrderDate { get; set; }
        public string Status { get; set; }

        public int ClientId { get; set; }

        [JsonIgnore] public Client Client { get; }

        public ICollection<ProductOrder> ProductOrders { get; set; }
    }
}