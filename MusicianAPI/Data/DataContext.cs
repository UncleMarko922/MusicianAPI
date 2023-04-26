using Microsoft.EntityFrameworkCore;

namespace MusicianAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        
        public DbSet<Musician> FavoriteMusicians { get; set; }
        public DbSet<FavoriteArtist> FavoriteArtists { get; set; }
        public DbSet<FavoriteGenre> FavoriteGenres { get; set; }
    }
}
