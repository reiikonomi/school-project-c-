using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YourNamespace.Entities;

namespace YourNamespace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersDemographicsController : ControllerBase
    {
        private readonly NorthwindContext _context;

        public CustomersDemographicsController(NorthwindContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerDemographics>>> GetCustomerDemographics()
        {
            return await _context.CustomerDemographics.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDemographics>> GetCustomerDemographics(int id)
        {
            var yourEntity = await _context.CustomerDemographics.FindAsync(id);

            if (yourEntity == null)
            {
                return NotFound();
            }

            return yourEntity;
        }

        [HttpPost]
        public async Task<ActionResult<CustomerDemographics>> PostYourEntity(CustomerDemographics customerDemographics)
        {
            _context.CustomerDemographics.Add(customerDemographics);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCustomerDemographics), new { id = customerDemographics.CustomerTypeId }, customerDemographics);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutYourEntity(int id, CustomerDemographics customerDemographics)
        {
            if (id.ToString() != customerDemographics.CustomerTypeId)
            {
                return BadRequest();
            }

            _context.Entry(customerDemographics).State = EntityState.Modified;

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
            var yourEntity = await _context.CustomerDemographics.FindAsync(id);
            if (yourEntity == null)
            {
                return NotFound();
            }

            _context.CustomerDemographics.Remove(yourEntity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool YourEntityExists(int id)
        {
            return _context.CustomerDemographics.Any(e => e.CustomerTypeId == id.ToString());
        }
    }
}
