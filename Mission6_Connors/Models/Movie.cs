using System.ComponentModel.DataAnnotations;

namespace Mission6_Connors.Models
{
    public class Movie
    {
        [Key] // Marks MovieId as the Primary Key
        [Required]
        public int MovieId { get; set; } // Auto-increment primary key

        [Required]
        public string Title { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public string Director { get; set; }

        [Required]
        public string Rating { get; set; }  // G, PG, PG-13, R

        public bool? Edited { get; set; } // Nullable boolean for Yes/No

        public string? LentTo { get; set; } // Nullable field

        [MaxLength(25)] // Ensures the Notes field is at most 25 characters
        public string? Notes { get; set; } // Nullable field
    }
}