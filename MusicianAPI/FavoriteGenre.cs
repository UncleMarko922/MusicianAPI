using System.ComponentModel.DataAnnotations;

namespace MusicianAPI
{
    public class FavoriteGenre
    {
        [Key]
        public int GenreId { get; set; }
        public string Genre { get; set; }
    }
}