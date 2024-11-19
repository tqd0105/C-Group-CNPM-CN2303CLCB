using KoiManagement.Repositories.Interfaces;
using KoiManagement.Repositories.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace KoiManagement.WebApplication.Pages.Appoint
{
    public class DeleteModel : PageModel
    {
        private readonly IAppointmentService _service;

        public DeleteModel(IAppointmentService service)
        {
            _service = service;
        }

        [BindProperty]
        public Appointment Appointment { get; set; } = new Appointment();

        // Lấy thông tin cuộc hẹn cần xóa dựa trên ID
        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            Appointment = await _service.GetByIdAsync(id);

            if (Appointment == null)
            {
                return NotFound();
            }

            return Page();
        }

        // Xóa cuộc hẹn khi người dùng xác nhận
        public async Task<IActionResult> OnPostAsync()
        {
            if (Appointment.AppointmentId == null)
            {
                return NotFound();
            }

            await _service.DeleteAsync(Appointment.AppointmentId);
            return RedirectToPage("./Index");
        }
    }
}
