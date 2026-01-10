using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication5.Data;

namespace WebApplication5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmTypesController : ControllerBase
    {
        private readonly CinemaDbContext _context;
        public FilmTypesController(CinemaDbContext context) { _context = context; }

        [HttpGet("feladat11")]
        public async Task<IActionResult> GetFilmTypes()
        {
            try
            {
                var types = await _context.FilmTypes
                    .Include(f => f.Movies)
                    .OrderBy(f => f.FilmTypeId)
                    .ToListAsync();
                return Ok(types);
            }
            catch { return BadRequest(); }
        }
    }
}