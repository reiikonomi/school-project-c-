using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YourNamespace.Entities;

/*

    FIXME:
    typo in the db sql file, should be OrderDetails not Order Details. 
    This makes the controller unusable unless changed in db sql file.

*/
namespace YourNamespace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDtailsController : ControllerBase
    {

        private readonly NorthwindContext _context;

        public OrderDtailsController(NorthwindContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDetails>>> GetOrderDetails()
        {
            return await _context.OrderDetails.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDetails[]>> GetOrderDetails(int id)
        {
            var yourEntity = await _context.OrderDetails.Where(e => e.OrderID == id).ToArrayAsync();

            if (yourEntity == null)
            {
                return NotFound();
            }

            return yourEntity;
        }

        [HttpPost]
        public async Task<ActionResult<OrderDetails>> PostYourEntity(OrderDetails orderDetails)
        {
            _context.OrderDetails.Add(orderDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetOrderDetails), new { id = orderDetails.OrderID }, orderDetails);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutYourEntity(int id, OrderDetails orderDetails)
        {
            if (id != orderDetails.OrderID)
            {
                return BadRequest();
            }

            _context.Entry(orderDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();

                return NoContent();
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
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteYourEntity(int id)
        {
            var yourEntity = await _context.OrderDetails.FindAsync(id);

            if (yourEntity == null)
            {
                return NotFound();
            }

            _context.OrderDetails.Remove(yourEntity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool YourEntityExists(int id)
        {
            return _context.OrderDetails.Any(e => e.OrderID == id);
        }
    }

}