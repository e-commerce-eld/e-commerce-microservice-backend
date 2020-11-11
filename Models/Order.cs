namespace OrdemExample.Models
{
    public class Order
    {
        public int OrderId {get;set;}
        public string Description{get;set;}
        public float Value{get;set;}
        public string Address{get;set;}

        public Client Client {get;set;}
        public int ClientId{get;set;}

    }
}