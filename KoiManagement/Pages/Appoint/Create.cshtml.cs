using KoiManagement.Repositories.Interfaces;
using KoiManagement.Repositories.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace KoiManagement.WebApplication.Pages.Appoint
{
    public class CreateModel : PageModel
    {
        private readonly IAppointmentService _service;

        public CreateModel(IAppointmentService service)
        {
            _service = service;
        }

        [BindProperty]
        public Appointment Appointment { get; set; } = new Appointment();

        public IActionResult OnGet()
        {
            // Khởi tạo giá trị mặc định cho cuộc hẹn mới
            Appointment.Status = "Pending";
            Appointment.AppointmentDate = System.DateTime.Now;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Kiểm tra xem AppointmentId đã tồn tại chưa (đảm bảo không trùng lặp)
            var existingAppointment = await _service.GetByIdAsync(Appointment.AppointmentId);
            if (existingAppointment != null)
            {
                ModelState.AddModelError("Appointment.AppointmentId", "Appointment ID already exists.");
                return Page();
            }

            await _service.AddAsync(Appointment);
            return RedirectToPage("./Index");
        }
    }
}
