using System.ComponentModel.DataAnnotations;

namespace AlbumsGraphQL.Models
{
    public class Artist
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Country { get; set; }
        public ICollection<Album> Albums { get; set; } = new List<Album>();
    }

}
