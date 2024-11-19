using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KoiManagement.Repositories.Models
{
    [Table("appointments")]
    public class Appointment
    {
        [Key]
        [Column("appointment_id")]
        [StringLength(10)]
        public string AppointmentId { get; set; } = string.Empty;

        [Required]
        [Column("customer_id")]
        [StringLength(10)]
        public string CustomerId { get; set; } = string.Empty;

        [Required]
        [Column("vet_id")]
        [StringLength(10)]
        public string VetId { get; set; } = string.Empty;

        [Required]
        [Column("appointment_date")]
        [DataType(DataType.DateTime)]
        public DateTime AppointmentDate { get; set; } = DateTime.Now;

        [Column("status")]
        [StringLength(50)]
        public string Status { get; set; } = "Pending";
    }
}
