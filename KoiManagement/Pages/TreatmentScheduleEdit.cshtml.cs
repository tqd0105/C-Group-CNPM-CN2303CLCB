using KoiManagement.WebApplication.Data;
using KoiManagement.WebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace KoiManagement.WebApplication.Pages
{
    public class TreatmentScheduleEditModel : PageModel
    {
        private readonly KoiManagementWebApplicationContext _context;

        public TreatmentScheduleEditModel(KoiManagementWebApplicationContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TreatmentSchedule TreatmentSchedule { get; set; }

        // Phương thức OnGetAsync sẽ được gọi khi trang được tải để hiển thị lịch bác sĩ
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound(); // Nếu không tìm thấy ID thì trả về lỗi NotFound
            }

            // Lấy thông tin lịch bác sĩ từ cơ sở dữ liệu theo ID
            TreatmentSchedule = await _context.TreatmentSchedule
                .FirstOrDefaultAsync(m => m.Id == id);

            if (TreatmentSchedule == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                // Log or inspect ModelState errors
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    // Bạn có thể sử dụng Console.WriteLine hoặc một logger để ghi lại lỗi
                    Console.WriteLine(error.ErrorMessage);
                }
                return Page();
            }

            var scheduleToUpdate = await _context.TreatmentSchedule.FindAsync(id);

            if (scheduleToUpdate == null)
            {
                return NotFound();
            }

            scheduleToUpdate.CustomerName = TreatmentSchedule.CustomerName;
            scheduleToUpdate.KoiName = TreatmentSchedule.KoiName;
            scheduleToUpdate.DiseaseSymptoms = TreatmentSchedule.DiseaseSymptoms;
            scheduleToUpdate.AppointmentDate = TreatmentSchedule.AppointmentDate;

            await _context.SaveChangesAsync();

            return RedirectToPage("./TreatmentSchedule");
        }
    }
}
