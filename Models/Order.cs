using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Commerce.Interfaces;
using Commerce.Models;
using System.Linq;

namespace Commerce.Models

{
    public class Order : IOrder
    {
        [Key] public int OrderId { get; set; }
        [Required] public int OrderNumber { get; set; }
        [Required] public DateTime OrderDate { get; set; }
        public string Status { get; set; }

        public int ClientId { get; set; }

        [JsonIgnore] public Client Client { get; }

        public ICollection<ProductOrder> ProductOrders { get; set; }

        private readonly OrderContext _context;

        public Order(OrderContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Order>> GetOrderFromClient(int id)
        {

            return await _context.Orders
                            .Where(o => o.ClientId == id).ToListAsync();
        }

        public async Task<ICollection<Product>> GetProductsfromOrder(int id)
        {

            //return await _context.Products
            //              .FromSqlInterpolated($"select id, name, price, description, categoryid from Products inner join ProductOrders on ProductOrders.ProductId = ProductId and ProductOrders.OrderId = {id} ;").ToListAsync();

            //return await _context.Orders.Include(o => o.ProductOrders).ThenInclude(po => po.Product).Where(o => o.OrderId == id).ToListAsync();
            return await _context.Products.Include(p => p.ProductOrders).Where(p => p.ProductOrders.Any(po => po.OrderId == id) ).ToListAsync();


        }

    }
 
}