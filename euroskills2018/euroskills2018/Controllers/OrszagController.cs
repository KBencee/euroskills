using euroskills2018.Data;
using euroskills2018.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace euroskills2018.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrszagController : Controller
    {
        private readonly VersenyzoDbContext _context;
        public OrszagController(VersenyzoDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Orszag>>> GetOrszagok()
        {
            return await _context.Orszagok.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Orszag>> GetOrszag(int id)
        {
            var orszag = await _context.Orszagok.FindAsync(id);
            if (orszag == null)
            {
                return NotFound();
            }
            return orszag;
        }

        [HttpPatch]
        public async Task<ActionResult<Orszag>> UpdateOrszag(Orszag orszag)
        {
            var existingOrszag = await _context.Orszagok.FindAsync(orszag.Id);
            if (existingOrszag == null)
            {
                return NotFound();
            }
            existingOrszag.OrszagNev = orszag.OrszagNev;
            await _context.SaveChangesAsync();
            return existingOrszag;
        }

        [HttpPost]
        public async Task<ActionResult<Orszag>> CreateOrszag(Orszag orszag)
        {
            _context.Orszagok.Add(orszag);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetOrszag), new { id = orszag.Id }, orszag);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteOrszag(int id)
        {
            var orszag = await _context.Orszagok.FindAsync(id);
            if (orszag == null)
            {
                return NotFound();
            }
            _context.Orszagok.Remove(orszag);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
