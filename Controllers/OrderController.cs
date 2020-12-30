using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Description;
using AutoMapper;
using Commerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Commerce.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly OrderContext _context;
        private readonly IMapper _mapper;

        public OrderController(OrderContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Order
        [ResponseType(typeof(OrderDto))]
        [HttpGet]
        public async Task<ActionResult<OrderDto>> GetOrders()
        {
            var orders = await _context.Orders.ToListAsync();
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

            return order;
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