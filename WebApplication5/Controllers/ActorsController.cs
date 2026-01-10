using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication5.Data;

namespace WebApplication5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorsController : ControllerBase
    {
        private readonly CinemaDbContext _context;
        public ActorsController(CinemaDbContext context) { _context = context; }

        [HttpGet("feladat9/{name}")]
        public async Task<IActionResult> GetActorByName(string name)
        {
            var actor = await _context.Actors.Include(a => a.Movies)
                .FirstOrDefaultAsync(a => a.Name == name);
            if (actor == null) return NotFound();
            return Ok(actor);
        }

        [HttpGet("feladat12")]
        public async Task<IActionResult> GetCount() => Ok(await _context.Actors.CountAsync());
    }
}