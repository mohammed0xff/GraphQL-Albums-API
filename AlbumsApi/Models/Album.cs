using System.ComponentModel.DataAnnotations;

namespace AlbumsGraphQL.Models
{
    public class Album
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Genre { get; set; }
        [Required]
        public int ArtistId { get; set; }
        public Artist Artist { get; set; }
    }
}