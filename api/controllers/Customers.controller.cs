using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YourNamespace.Entities;

namespace YourNamespace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly NorthwindContext _context;

        public CustomersController(NorthwindContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customers>>> GetCustomers()
        {
            return await _context.Customers.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Customers>> GetCustomers(int id)
        {
            var yourEntity = await _context.Customers.FindAsync(id);

            if (yourEntity == null)
            {
                return NotFound();
            }

            return yourEntity;
        }

        [HttpPost]
        public async Task<ActionResult<Customers>> PostYourEntity(Customers customers)
        {
            _context.Customers.Add(customers);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCustomers), new { id = customers.CustomerID }, customers);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutYourEntity(int id, Customers customers)
        {
            if (id.ToString() != customers.CustomerID)
            {
                return BadRequest();
            }

            _context.Entry(customers).State = EntityState.Modified;

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
            var yourEntity = await _context.Customers.FindAsync(id);
            if (yourEntity == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(yourEntity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool YourEntityExists(int id)
        {
            return _context.Customers.Any(e => e.CustomerID == id.ToString());
        }
    }
}
