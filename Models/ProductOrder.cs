using System.Text.Json.Serialization;

namespace Commerce.Models
{
    public class ProductOrder
    {
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public int QuantityProduct { get; set; }

        [JsonIgnore] public Product Product { get; set; }
        [JsonIgnore] public Order Order { get; set; }
    }
}