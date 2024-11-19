using System;
using System.ComponentModel.DataAnnotations;

namespace KoiManagement.WebApplication.Models
{
    public class TreatmentSchedule
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Customer Name is required.")]
        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Phone is required.")]
        [Phone(ErrorMessage = "Invalid phone number.")]
        [Display(Name = "Phone")]
        public string Phone { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "The email address is not valid.")]
        [Display(Name = "Email")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Koi's Name is required.")]
        [Display(Name = "Koi's Name")]
        public string KoiName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Booking Date is required.")]
        [DataType(DataType.DateTime, ErrorMessage = "Invalid date format.")]
        [Display(Name = "Booking Date")]
        public DateTime BookingDate { get; set; }

        [Required(ErrorMessage = "Appointment Date is required.")]
        [DataType(DataType.DateTime, ErrorMessage = "Invalid date format.")]
        [Display(Name = "Appointment Date")]
        public DateTime AppointmentDate { get; set; }  // New Property for Appointment Date

        [Display(Name = "Veterinarian")]
        public string? VeterinarianName { get; set; }

        [Required(ErrorMessage = "Disease Symptoms are required.")]
        [Display(Name = "Disease Symptoms")]
        public string DiseaseSymptoms { get; set; } = string.Empty;  // New Property for Disease Symptoms

        [Display(Name = "Treatment Description")]
        public string Description { get; set; } = string.Empty;

        [Display(Name = "Prescription")]
        public string Prescription { get; set; } = string.Empty;  // New Property for Prescription

        [Display(Name = "Is Confirmed")]
        public bool IsConfirmed { get; set; } = false; // Default: Not Confirmed
    }
}
