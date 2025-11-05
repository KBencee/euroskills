using euroskills2018.Data;
using euroskills2018.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace euroskills2018.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SzakmaController : Controller
    {
        private readonly VersenyzoDbContext _context;
        public SzakmaController(VersenyzoDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Szakma>>> GetSzakmak()
        {
            return await _context.Szakmak.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Szakma>> GetSzakma(int id)
        {
            var szakma = await _context.Szakmak.FindAsync(id);
            if (szakma == null)
            {
                return NotFound();
            }
            return szakma;
        }

        [HttpPatch] 
        public async Task<ActionResult<Szakma>> UpdateSzakma(Szakma szakma)
        {
            var existingSzakma = await _context.Szakmak.FindAsync(szakma.Id);
            if (existingSzakma == null)
            {
                return NotFound();
            }
            existingSzakma.SzakmaNev = szakma.SzakmaNev;
            await _context.SaveChangesAsync();
            return existingSzakma;
        }

        [HttpPost]
        public async Task<ActionResult<Szakma>> CreateSzakma(Szakma szakma)
        {
            _context.Szakmak.Add(szakma);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetSzakma), new { id = szakma.Id }, szakma);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteSzakma(int id)
        {
            var szakma = await _context.Szakmak.FindAsync(id);
            if (szakma == null)
            {
                return NotFound();
            }
            _context.Szakmak.Remove(szakma);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
