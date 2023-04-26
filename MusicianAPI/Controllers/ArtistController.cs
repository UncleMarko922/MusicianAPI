using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicianAPI.Data;

namespace MusicianAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        private readonly DataContext _context;

        public ArtistController(DataContext dataContext)
        {
            _context = dataContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<FavoriteArtist>>> Get()
        {
            return Ok(await _context.FavoriteArtists.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FavoriteArtist>> Get(int id)
        {
            var musician = await _context.FavoriteArtists.FindAsync(id);
            if (musician == null)
                return BadRequest("Couldn't find the specified Artist");
            return Ok(musician);
        }

        [HttpPost]
        public async Task<ActionResult<List<Musician>>> AddArtist(FavoriteArtist artist)
        {
            _context.FavoriteArtists.Add(artist);
            await _context.SaveChangesAsync();

            return Ok(await _context.FavoriteMusicians.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<FavoriteArtist>>> UpdateMusician(FavoriteArtist request)
        {
            var artist = await _context.FavoriteArtists.FindAsync(request.ArtistId);
            if (artist == null)
                return BadRequest("Couldn't find them. Must be a poser");

            artist.Artist= request.Artist;
            artist.GenereId = request.GenereId;

            await _context.SaveChangesAsync();
            return Ok(artist);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<FavoriteArtist>>> DeleteArtist(int id)
        {
            var artist = await _context.FavoriteMusicians.FindAsync(id);
            if (artist == null)
                return BadRequest("Couldn't find them. Must be a poser");

            _context.FavoriteMusicians.Remove(artist);
            return Ok(await _context.FavoriteArtists.ToListAsync());
        }
    }
}
