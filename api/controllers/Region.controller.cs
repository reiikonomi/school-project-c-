using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YourNamespace.Entities;

namespace YourNamespace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        private readonly NorthwindContext _context;

        public RegionController(NorthwindContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Region>>> GetRegion()
        {
            return await _context.Region.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Region>> GetRegion(int id)
        {
            var region = await _context.Region.FindAsync(id);

            if (region == null)
            {
                return NotFound();
            }

            return region;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutRegion(int id, Region region)
        {
            if (id != region.RegionID)
            {
                return BadRequest();
            }

            _context.Entry(region).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegionExists(id))
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
        public async Task<ActionResult<Region>> PostRegion(Region region)
        {
            _context.Region.Add(region);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRegion", new { id = region.RegionID }, region);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Region>> DeleteRegion(int id)
        {
            var region = await _context.Region.FindAsync(id);
            if (region == null)
            {
                return NotFound();
            }

            _context.Region.Remove(region);
            await _context.SaveChangesAsync();

            return region;
        }

        private bool RegionExists(int id)
        {
            return _context.Region.Any(e => e.RegionID == id);
        }
    }

}