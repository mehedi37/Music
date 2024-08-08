using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCTest.Models
{
    public class Musics
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }

        public string Title { get; set; } = string.Empty; 

        /*Cover pic*/
        public string Cover { get; set; } = string.Empty;  

        [ForeignKey("Artist")]
        public int? ArtistId { get; set; }

        [DeleteBehavior(DeleteBehavior.Restrict)]
        public Artist? Artist { get; set; } // Make nullable

        [ForeignKey("Album")]
        public int? AlbumId { get; set; }

        [DeleteBehavior(DeleteBehavior.Restrict)]
        public Album? Album { get; set; } // Make nullable

        public string Genre { get; set; } = string.Empty;

        public required DateOnly ReleaseDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);
    }
}
