using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCTest.Models
{
    public class Album
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }

        public string Title { get; set; } = string.Empty; // Initialize with default value

        [ForeignKey("Artist")]
        public int? ArtistId { get; set; }

        [DeleteBehavior(DeleteBehavior.Restrict)]
        public Artist? Artist { get; set; } // Make nullable

        public required DateOnly ReleaseDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);
    }
}
