using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
