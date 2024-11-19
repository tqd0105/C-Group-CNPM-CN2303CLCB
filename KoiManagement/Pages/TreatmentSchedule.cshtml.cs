using KoiManagement.WebApplication.Data;
using KoiManagement.WebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace KoiManagement.WebApplication.Pages
{
    public class TreatmentScheduleModel : PageModel
    {
        private readonly KoiManagementWebApplicationContext _context;

        public TreatmentScheduleModel(KoiManagementWebApplicationContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TreatmentSchedule TreatmentSchedule { get; set; }

        public List<TreatmentSchedule> Schedule { get; set; } = new List<TreatmentSchedule>();

        public async Task OnGetAsync(string CustomerName, string KoiName, string Phone, string Email, DateTime? BookingDate, DateTime? AppointmentDate, string DiseaseSymptoms, string Prescription)
        {

            var schedules = from s in _context.TreatmentSchedule
                            select s;

            if (!string.IsNullOrEmpty(CustomerName))
            {
                schedules = schedules.Where(s => s.CustomerName.Contains(CustomerName));
            }

            if (!string.IsNullOrEmpty(KoiName))
            {
                schedules = schedules.Where(s => s.KoiName.Contains(KoiName));
            }

            if (!string.IsNullOrEmpty(Phone))
            {
                schedules = schedules.Where(s => s.Phone.Contains(Phone));
            }

            if (!string.IsNullOrEmpty(Email))
            {
                schedules = schedules.Where(s => s.Email.Contains(Email));
            }

            if (BookingDate.HasValue)
            {
                schedules = schedules.Where(s => s.BookingDate.Date == BookingDate.Value.Date);
            }


            if (AppointmentDate.HasValue)
            {
                schedules = schedules.Where(s => s.AppointmentDate.Date == AppointmentDate.Value.Date);
            }

            Schedule = await schedules.ToListAsync();
        }

        // Phương thức OnPostAsync để lưu lịch bác sĩ mới
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                // Thêm lịch bác sĩ mới vào cơ sở dữ liệu
                _context.TreatmentSchedule.Add(TreatmentSchedule);
                await _context.SaveChangesAsync();
                return RedirectToPage(); // Quay lại trang sau khi thêm thành công
            }
            return Page(); // Trả về trang hiện tại nếu có lỗi hợp lệ
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var schedule = await _context.TreatmentSchedule.FindAsync(id);
            if (schedule != null)
            {
                _context.TreatmentSchedule.Remove(schedule);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage();
        }
    }
}
