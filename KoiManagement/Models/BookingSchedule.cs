using System.ComponentModel.DataAnnotations;

namespace KoiManagement.WebApplication.Models
{
    public class BookingSchedule
    {
        public int Id { get; set; }
        [Display(Name ="Name")]
        public string name { get; set; } = string.Empty;
        [Display(Name = "Phone")]
        public string phone { get; set; } = string.Empty;
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "The email address is not valid.")]
        public string? email { get; set; }
        [Display(Name = "Koi's Name")]
        public string koi_name { get; set; } = string.Empty;
        [Display(Name = "Booking Date")]
        public DateTime Booking_Date  { get; set; }
        [Display(Name = "Vets")]
        public string? vets_name { get; set; }
        [Display(Name = "Address")]
        public string address { get; set; } = string.Empty;
        [Display(Name = "Description")]
        public string description { get; set; } = string.Empty;
    }
}
