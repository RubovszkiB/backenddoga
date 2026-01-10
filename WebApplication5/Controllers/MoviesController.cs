using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication5.Data;

namespace WebApplication5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly CinemaDbContext _context;
        public MoviesController(CinemaDbContext context) { _context = context; }

        [HttpGet("feladat10")]
        public async Task<IActionResult> GetMovies()
        {
            try
            {
                return Ok(await _context.Movies.Include(m => m.Actor).Include(m => m.FilmType)
                    .OrderBy(m => m.MovieId).ToListAsync());
            }
            catch { return BadRequest(); }
        }
    }
}