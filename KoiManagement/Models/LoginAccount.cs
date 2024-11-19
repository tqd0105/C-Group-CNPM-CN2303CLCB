using System.ComponentModel.DataAnnotations;

namespace KoiManagement.WebApplication.Models
{
    public class LoginAccount
    {
        public int Id { get; set; }
        [Display(Name = "Full Name")]
        public string name { get; set; }
        [Display(Name = "Phone")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must be exactly 10 digits.")]
        public string username { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string password { get; set; }
        [Display(Name = "Address")]
        public string address { get; set; }
        [Display(Name = "Birthday")]
        public DateOnly birthday { get; set; }
    }
}
