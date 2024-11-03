namespace KoiManagement.WebApplication.Models
{
    public class PetService
    {
        public int Id { get; set; }
        public string? PetName { get; set; } 
        public string? OwnerName { get; set; } 
        public string? ServiceType { get; set; } 

        public string? DoctorName {  get; set; }
        public int? Rating { get; set; }
        public string? Feedback { get; set; } = string.Empty;
    public DateTime ServiceDate { get; set; }

   public DateTime ServiceDate { get; set; }

    }
}
