using System.ComponentModel.DataAnnotations;

namespace MusicianAPI
{
    public class Musician
    {
        [Key]
        public int ID { get; set; }
        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string? StageName { get; set; } = null;
        public List<FavoriteArtist> ArtistId { get; set; }
        public string? Instrument { get; set; } = null;

        public string? Vocals { get; set; } = null;

    }
}
