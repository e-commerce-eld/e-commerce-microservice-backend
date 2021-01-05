using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Description;
using AutoMapper;
using Commerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Commerce.Models;
using Commerce.Interfaces;

namespace Commerce.Controllers

{
    
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly OrderContext _context;
        private IOrder orderObject;
        private readonly IMapper _mapper;

        public OrderController(OrderContext context, IOrder orderOb,  IMapper mapper)
        {
            _context = context;
            orderObject = orderOb;
            _mapper = mapper;
        }

        

        // GET: api/Order
        [ResponseType(typeof(OrderDto))]
        [HttpGet]
        public async Task<ActionResult<OrderDto>> GetOrders()
        {
            var orders = await _context.Orders.Include(p => p.ProductOrders).ToListAsync();
            return Ok(_mapper.Map<IEnumerable<OrderDto>>(orders));
        }

        // GET: api/Order/5

        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);

            if (order == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<IEnumerable<OrderDto>>(order));
        }

        // GET: api/Order/Client/5
        [HttpGet("client/{id}")]
        public async Task<ICollection<Order>> GetOrderfromClient(int id)
        {
            //ICollection<Order> myresult;
            var order = await orderObject.GetOrderFromClient(id);

           // myresult = order;

            if (order == null)
            {
                //return NotFound();
            }

            return order;
        }

        [HttpGet("{id}/products")]
        public async Task<ICollection<Product>> GetProductFromOrder(int id)
        {
            //ICollection<Order> myresult;
            var products = await orderObject.GetProductsfromOrder(id);

            // myresult = order;

            if (products == null)
            {
                //return NotFound();
                return null;
            }

            return products;
        }
        // PUT: api/Order/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        public async Task<IActionResult> PutOrder(int id, Order order)
        {
            if (id != order.OrderId)
            {
                return BadRequest();
            }

            _context.Entry(order).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Order
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(Order order)
        {
            //  var relation = new ProductOrder();
            //relation.OrderId = order.OrderId;
            //relation.ProductId = order.ProductId;

            _context.Orders.Add(order);

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrder", new {id = order.OrderId}, order);
        }

        // DELETE: api/Order/5

        public async Task<ActionResult<Order>> DeleteOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            return order;
        }

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.OrderId == id);
        }
    }
}