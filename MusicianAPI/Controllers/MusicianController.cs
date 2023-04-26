using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicianAPI.Data;

namespace MusicianAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicianController : ControllerBase
    {
        private readonly DataContext _context;

        public MusicianController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Musician>>> Get()
        {
            return Ok(await _context.FavoriteMusicians.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Musician>> Get(int id)
        {
            var musician = await _context.FavoriteMusicians.FindAsync(id);
            if (musician == null)
                return BadRequest("Couldn't find them. Must be a poser");
            return Ok(musician);
        }

        [HttpPost]
        public async Task<ActionResult<List<Musician>>> AddMusician(Musician musician)
        {
            _context.FavoriteMusicians.Add(musician);
            await _context.SaveChangesAsync();

            return Ok(await _context.FavoriteMusicians.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Musician>>> UpdateMusician(Musician request)
        {
            var musician = await _context.FavoriteMusicians.FindAsync(request.ID);
            if (musician == null)
                return BadRequest("Couldn't find them. Must be a poser");

            musician.FirstName = request.FirstName;
            musician.LastName = request.LastName;
            musician.ArtistId= request.ArtistId;
            musician.StageName = request.StageName;
            musician.Instrument = request.Instrument;
            musician.Vocals = request.Vocals;

            await _context.SaveChangesAsync();
            return Ok(musician);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Musician>>> DeleteMusician(int id)
        {
            var musician = await _context.FavoriteMusicians.FindAsync(id);
            if (musician == null)
                return BadRequest("Couldn't find them. Must be a poser");

            _context.FavoriteMusicians.Remove(musician);
            return Ok(await _context.FavoriteMusicians.ToListAsync());
        }
    }
}
