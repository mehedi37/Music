using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCTest.Models
{
    public class Artist
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }
        public required string Name { get; set; }
        public string? Age { get; set; } 
    }
}
