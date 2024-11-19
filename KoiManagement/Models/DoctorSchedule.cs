using System;
using System.ComponentModel.DataAnnotations;

namespace KoiManagement.WebApplication.Models
{
    public class DoctorSchedule
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Doctor Name is required.")]
        [Display(Name = "Doctor Name")]
        public string DoctorName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Working Day is required.")]
        [DataType(DataType.Date, ErrorMessage = "Invalid date format.")]
        [Display(Name = "Working Day")]
        public DateTime WorkingDay { get; set; }

        [Required(ErrorMessage = "Shift is required.")]
        [Display(Name = "Shift")]
        public string Shift { get; set; } = string.Empty;

        [Display(Name = "Replacement Doctor")]
        public string? ReplacementDoctor { get; set; }

        [Display(Name = "Is Available")]
        public bool IsAvailable { get; set; } = true; // Default: Available

    }
}
