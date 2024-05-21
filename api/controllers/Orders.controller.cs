using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YourNamespace.Entities;

namespace YourNamespace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {

        private readonly NorthwindContext _context;

        public OrdersController(NorthwindContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Orders>>> GetOrders()
        {
            return await _context.Orders.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Orders>> GetOrders(int id)
        {
            var yourEntity = await _context.Orders.FindAsync(id);

            if (yourEntity == null)
            {
                return NotFound();
            }

            return yourEntity;
        }

        [HttpGet("customer/{id}")]
        public async Task<ActionResult<Orders[]>> GetOrdersByCustomerID(string id)
        {
            var yourEntity = await _context.Orders.Where(e => e.CustomerID == id).ToArrayAsync();

            if (yourEntity == null)
            {
                return NotFound();
            }

            return yourEntity;
        }

        [HttpGet("employee/{id}")]
        public async Task<ActionResult<Orders[]>> GetOrdersByEmployeeID(int id)
        {
            var yourEntity = await _context.Orders.Where(e => e.EmployeeID == id).ToArrayAsync();

            if (yourEntity == null)
            {
                return NotFound();
            }

            return yourEntity;
        }

        [HttpPost]
        public async Task<ActionResult<Orders>> PostYourEntity(Orders orders)
        {
            _context.Orders.Add(orders);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetOrders), new { id = orders.OrderID }, orders);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutYourEntity(int id, Orders orders)
        {
            if (id != orders.OrderID)
            {
                return BadRequest();
            }

            _context.Entry(orders).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!YourEntityExists(id))
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteYourEntity(int id)
        {
            var yourEntity = await _context.Orders.FindAsync(id);
            if (yourEntity == null)
            {
                return NotFound();
            }

            _context.Orders.Remove(yourEntity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool YourEntityExists(int id)
        {
            return _context.Orders.Any(e => e.OrderID == id);
        }
    }

}