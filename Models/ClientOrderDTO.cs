using System;
using System.Collections.Generic;

namespace Commerce.Models
{
    public class ClientOrderDto
    {
        public string ClientName { get; set; }
        public int OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }

        public ICollection<ProductOrderDto> ProductOrders { get; set; }
    }
}