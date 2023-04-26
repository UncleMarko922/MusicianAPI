using System.ComponentModel.DataAnnotations;

namespace MusicianAPI
{
    public class FavoriteArtist
    {
        [Key]
        public int ArtistId { get; set; }
        public string Artist { get; set; } = string.Empty;
        public FavoriteGenre GenereId { get; set; }
    }
}
