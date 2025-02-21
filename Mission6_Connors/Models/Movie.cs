using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission6_Connors.Models
{
    public class Movie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Ensures Auto-Increment
        public int MovieId { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public int CategoryId { get; set; } // Foreign Key

        [ForeignKey("CategoryId")]
        public Category? Category { get; set; } // Navigation Property

        [Required]
        public int Year { get; set; }

        [Required]
        public string Director { get; set; } = string.Empty;

        [Required]
        public string Rating { get; set; } = string.Empty;  // G, PG, PG-13, R

        [Required]
        public bool Edited { get; set; } = false; // Ensures default false

        public string? LentTo { get; set; } // Nullable field

        [MaxLength(25)]
        public string? Notes { get; set; } // Nullable Notes Field
    }
}