using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YourNamespace.Entities;

namespace YourNamespace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeTerritoriesController : ControllerBase
    {

        private readonly NorthwindContext _context;

        public EmployeeTerritoriesController(NorthwindContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeTerritories>>> GetEmployeeTerritories()
        {
            return await _context.EmployeeTerritories.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeTerritories[]>> GetEmployeeTerritories(int id)
        {
            var yourEntity = await _context.EmployeeTerritories.Where(e => e.EmployeeID == id).ToArrayAsync();

            if (yourEntity == null)
            {
                return NotFound();
            }

            return yourEntity;
        }

        [HttpPost]
        public async Task<ActionResult<EmployeeTerritories>> PostYourEntity(EmployeeTerritories employeeTerritories)
        {
            _context.EmployeeTerritories.Add(employeeTerritories);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEmployeeTerritories), new { id = employeeTerritories.EmployeeID }, employeeTerritories);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutYourEntity(int id, EmployeeTerritories employeeTerritories)
        {
            if (id != employeeTerritories.EmployeeID)
            {
                return BadRequest();
            }

            _context.Entry(employeeTerritories).State = EntityState.Modified;

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

        private bool YourEntityExists(int id)
        {
            return _context.EmployeeTerritories.Any(e => e.EmployeeID == id);
        }
    }
}