using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KoiManagement.Repositories.Models
{
    [Table("ratings")]
    public class Rating
    {
        [Key]
        [Column("rating_id")]
        [StringLength(10)]
        public string RatingId { get; set; } = string.Empty;

        [Required]
        [Column("vet_id")]
        [StringLength(10)]
        public string VetId { get; set; } = string.Empty;

        [Required]
        [Column("user_id")]
        [StringLength(10)]
        public string UserId { get; set; } = string.Empty;

        [Required]
        [Column("rating")]
        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5")]
        public int RatingValue { get; set; }

        [Column("feedback")]
        public string? Feedback { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
