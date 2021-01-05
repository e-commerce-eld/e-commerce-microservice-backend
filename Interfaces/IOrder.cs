using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Commerce.Models;

namespace Commerce.Interfaces
{
    public interface IOrder
    {
        Task<ICollection<Order>> GetOrderFromClient(int id);

        Task<ICollection<Product>> GetProductsfromOrder(int id);
    }
}
