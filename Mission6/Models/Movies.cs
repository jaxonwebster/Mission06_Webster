using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Mission06_Webster.Models;

namespace Mission6.Models


{
    public class Movies
    {
        [Key]
        [Required]
        public int MovieId { get; set; }

        [ForeignKey("Category")]
        public int? CategoryId { get; set; }  // Nullable to match the database

        [Required]
        public string Title { get; set; }  // NOT NULL in the database

        [Required]
        public int Year { get; set; }  // NOT NULL in the database

        public string? Director { get; set; }  // Can be NULL

        public string? Rating { get; set; }  // Can be NULL

        [Required]
        public bool Edited { get; set; }  // NOT NULL, so it stays required

        public string? LentTo { get; set; }  // Can be NULL

        [Required]
        public int CopiedToPlex { get; set; }  // NOT NULL in the database

        public string? Notes { get; set; }  // Can be NULL

        // Navigation Property
        public Category? Category { get; set; }
    }
}

