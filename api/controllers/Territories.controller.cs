using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YourNamespace.Entities;

namespace YourNamespace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TerritoriesController : ControllerBase
    {
        private readonly NorthwindContext _context;

        public TerritoriesController(NorthwindContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Territories>>> GetTerritories()
        {
            return await _context.Territories.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Territories>> GetTerritories(int id)
        {
            var territories = await _context.Territories.FindAsync(id);

            if (territories == null)
            {
                return NotFound();
            }

            return territories;
        }

        [HttpGet("region/{id}")]
        public async Task<ActionResult<Territories[]>> GetTerritoriesByRegionID(int id)
        {
            var territories = await _context.Territories.Where(e => e.RegionID == id).ToArrayAsync();

            if (territories == null)
            {
                return NotFound();
            }

            return territories;
        }

        [HttpPost]
        public async Task<ActionResult<Territories>> PostTerritories(Territories territories)
        {
            _context.Territories.Add(territories);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTerritories), new { id = territories.TerritoryID }, territories);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTerritories(int id, Territories territories)
        {
            if (id.ToString() != territories.TerritoryID)
            {
                return BadRequest();
            }

            _context.Entry(territories).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TerritoriesExists(id))
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

        private bool TerritoriesExists(int id)
        {
            return _context.Territories.Any(e => e.TerritoryID == id.ToString());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Territories>> DeleteTerritories(int id)
        {
            var territories = await _context.Territories.FindAsync(id);
            if (territories == null)
            {
                return NotFound();
            }

            _context.Territories.Remove(territories);
            await _context.SaveChangesAsync();

            return territories;
        }

    }

}