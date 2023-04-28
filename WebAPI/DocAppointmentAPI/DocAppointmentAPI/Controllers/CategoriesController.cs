using DocAppointmentAPI.Entities.DataTransferObjects;
using DocAppointmentAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DocAppointmentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly RepositoryContext _context;

        public CategoriesController(RepositoryContext context)
        {
            _context = context;
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryWithDoctorsCountDto>>> GetCategoriesWithDoctorsCount(string? categoryName = null)
        {
            var categoriesQuery = _context.Categories.AsQueryable();

            if (!string.IsNullOrEmpty(categoryName))
            {
                categoriesQuery = categoriesQuery.Where(c => c.Name.Contains(categoryName));
            }

            var categoriesWithDoctorsCount = await categoriesQuery.Select(c =>
                new CategoryWithDoctorsCountDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    DoctorsCount = _context.Users.Count(u => u.CategoryId == c.Id)
                }).ToListAsync();

            return categoriesWithDoctorsCount;
        }

        //    // GET: api/Categories/5
        //    [HttpGet("{id}")]
        //    public async Task<ActionResult<Category>> GetCategory(Guid id)
        //    {
        //      if (_context.Categories == null)
        //      {
        //          return NotFound();
        //      }
        //        var category = await _context.Categories.FindAsync(id);

        //        if (category == null)
        //        {
        //            return NotFound();
        //        }

        //        return category;
        //    }

        //    // PUT: api/Categories/5
        //    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //    [HttpPut("{id}")]
        //    public async Task<IActionResult> PutCategory(Guid id, Category category)
        //    {
        //        if (id != category.Id)
        //        {
        //            return BadRequest();
        //        }

        //        _context.Entry(category).State = EntityState.Modified;

        //        try
        //        {
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!CategoryExists(id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }

        //        return NoContent();
        //    }

        //    // POST: api/Categories
        //    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //    [HttpPost]
        //    public async Task<ActionResult<Category>> PostCategory(Category category)
        //    {
        //      if (_context.Categories == null)
        //      {
        //          return Problem("Entity set 'RepositoryContext.Categories'  is null.");
        //      }
        //        _context.Categories.Add(category);
        //        await _context.SaveChangesAsync();

        //        return CreatedAtAction("GetCategory", new { id = category.Id }, category);
        //    }

        //    // DELETE: api/Categories/5
        //    [HttpDelete("{id}")]
        //    public async Task<IActionResult> DeleteCategory(Guid id)
        //    {
        //        if (_context.Categories == null)
        //        {
        //            return NotFound();
        //        }
        //        var category = await _context.Categories.FindAsync(id);
        //        if (category == null)
        //        {
        //            return NotFound();
        //        }

        //        _context.Categories.Remove(category);
        //        await _context.SaveChangesAsync();

        //        return NoContent();
        //    }

        //    private bool CategoryExists(Guid id)
        //    {
        //        return (_context.Categories?.Any(e => e.Id == id)).GetValueOrDefault();
        //    }
    }
}
