using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YourNamespace.Entities;

namespace YourNamespace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        private readonly NorthwindContext _context;

        public EmployeeController(NorthwindContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employees>>> GetEmployees()
        {
            return await _context.Employees.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employees>> GetEmployees(int id)
        {
            var yourEntity = await _context.Employees.FindAsync(id);

            if (yourEntity == null)
            {
                return NotFound();
            }

            return yourEntity;
        }

        [HttpPost]
        public async Task<ActionResult<Employees>> PostYourEntity(Employees employees)
        {
            _context.Employees.Add(employees);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEmployees), new { id = employees.EmployeeID }, employees);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutYourEntity(int id, Employees employees)
        {
            if (id != employees.EmployeeID)
            {
                return BadRequest();
            }

            _context.Entry(employees).State = EntityState.Modified;

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
            var yourEntity = await _context.Employees.FindAsync(id);
            if (yourEntity == null)
            {
                return NotFound();
            }

            _context.Employees.Remove(yourEntity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool YourEntityExists(int id)
        {
            return _context.Employees.Any(e => e.EmployeeID == id);
        }

    }
}