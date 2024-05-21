using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YourNamespace.Entities;

namespace YourNamespace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly NorthwindContext _context;

        public ProductsController(NorthwindContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Products>>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Products>> GetProducts(int id)
        {
            var yourEntity = await _context.Products.FindAsync(id);

            if (yourEntity == null)
            {
                return NotFound();
            }

            return yourEntity;
        }

        [HttpGet("category/{id}")]
        public async Task<ActionResult<Products[]>> GetProductsByCategoryID(int id)
        {
            var yourEntity = await _context.Products.Where(e => e.CategoryID == id).ToArrayAsync();

            if (yourEntity == null)
            {
                return NotFound();
            }

            return yourEntity;
        }

        [HttpPost]
        public async Task<ActionResult<Products>> PostYourEntity(Products products)
        {
            _context.Products.Add(products);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProducts), new { id = products.ProductID }, products);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutYourEntity(int id, Products products)
        {
            if (id != products.ProductID)
            {
                return BadRequest();
            }

            _context.Entry(products).State = EntityState.Modified;

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
            var yourEntity = await _context.Products.FindAsync(id);
            if (yourEntity == null)
            {
                return NotFound();
            }

            _context.Products.Remove(yourEntity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool YourEntityExists(int id)
        {
            return _context.Products.Any(e => e.ProductID == id);
        }
    }
}