using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YourNamespace.Entities;

namespace YourNamespace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShippersController : ControllerBase
    {
        private readonly NorthwindContext _context;

        public ShippersController(NorthwindContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Shippers>>> GetShippers()
        {
            return await _context.Shippers.ToListAsync();
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<Shippers>> GetShippers(int id)
        {
            var shippers = await _context.Shippers.FindAsync(id);

            if (shippers == null)
            {
                return NotFound();
            }

            return shippers;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutShippers(int id, Shippers shippers)
        {
            if (id != shippers.ShipperID)
            {
                return BadRequest();
            }

            _context.Entry(shippers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShippersExists(id))
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

        [HttpPost]
        public async Task<ActionResult<Shippers>> PostShippers(Shippers shippers)
        {
            _context.Shippers.Add(shippers);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetShippers), new { id = shippers.ShipperID }, shippers);
        }

        private bool ShippersExists(int id)
        {
            return _context.Shippers.Any(e => e.ShipperID == id);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShippers(int id)
        {
            var shippers = await _context.Shippers.FindAsync(id);
            if (shippers == null)
            {
                return NotFound();
            }

            _context.Shippers.Remove(shippers);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}