using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Commerce.Interfaces;
namespace Commerce.Models

{
    public class Client
    {
        public int Id{get;set;}
        public string Name{get;set;}
        public string Cpf{get;set;}
        [JsonIgnore]
        public ICollection<Order> Orders { get; set;}

    }

//    public Order(){
//        return Order.where()
//    }
}