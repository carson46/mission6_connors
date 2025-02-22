using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission6_Connors.Models
{
    public class Movie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Ensures Auto-Increment
        public int MovieId { get; set; }

        public string? Title { get; set; } = string.Empty;

        public int? CategoryId { get; set; } // Nullable Foreign Key

        [ForeignKey("CategoryId")]
        public Category? Category { get; set; } // Nullable Navigation Property

        public int? Year { get; set; }

        public string? Director { get; set; } = string.Empty;

        public string? Rating { get; set; } = string.Empty; // G, PG, PG-13, R
        public bool Edited { get; set; } = false; // Ensures default false

        public string? LentTo { get; set; } // Nullable field

        [MaxLength(25)] public string? Notes { get; set; } // Nullable Notes Field

        [Required] 
        public bool CopiedToPlex { get; set; } = false; // Allow NULLs

    }
}