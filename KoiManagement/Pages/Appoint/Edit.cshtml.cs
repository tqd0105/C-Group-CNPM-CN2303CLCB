using KoiManagement.Repositories.Interfaces;
using KoiManagement.Repositories.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace KoiManagement.WebApplication.Pages.Appoint
{
    public class EditModel : PageModel
    {
        private readonly IAppointmentService _service;

        public EditModel(IAppointmentService service)
        {
            _service = service;
        }

        [BindProperty]
        public Appointment Appointment { get; set; } = new Appointment();

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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                await _service.UpdateAsync(Appointment);
            }
            catch
            {
                if (await _service.GetByIdAsync(Appointment.AppointmentId) == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }
    }
}
