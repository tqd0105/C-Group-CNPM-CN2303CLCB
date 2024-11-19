using KoiManagement.WebApplication.Data;
using KoiManagement.WebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace KoiManagement.WebApplication.Pages
{
    public class DoctorScheduleEditModel : PageModel
    {
        private readonly KoiManagementWebApplicationContext _context;

        public DoctorScheduleEditModel(KoiManagementWebApplicationContext context)
        {
            _context = context;
        }

        [BindProperty]
        public DoctorSchedule DoctorSchedule { get; set; }

        // Phương thức OnGetAsync sẽ được gọi khi trang được tải để hiển thị lịch bác sĩ
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound(); // Nếu không tìm thấy ID thì trả về lỗi NotFound
            }

            // Lấy thông tin lịch bác sĩ từ cơ sở dữ liệu theo ID
            DoctorSchedule = await _context.DoctorSchedule
                .FirstOrDefaultAsync(m => m.Id == id);

            if (DoctorSchedule == null)
            {
                return NotFound(); // Nếu không tìm thấy lịch bác sĩ thì trả về lỗi NotFound
            }

            return Page(); // Trả về trang để hiển thị lịch bác sĩ hiện tại
        }

        // Phương thức OnPostAsync để lưu các thay đổi khi người dùng chỉnh sửa lịch
        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page(); // Nếu dữ liệu không hợp lệ, hiển thị lại trang với lỗi
            }

            var scheduleToUpdate = await _context.DoctorSchedule.FindAsync(id);

            if (scheduleToUpdate == null)
            {
                return NotFound(); // Nếu không tìm thấy lịch bác sĩ, trả về lỗi NotFound
            }

            // Cập nhật thông tin lịch bác sĩ với dữ liệu mới từ form
            scheduleToUpdate.DoctorName = DoctorSchedule.DoctorName;
            scheduleToUpdate.WorkingDay = DoctorSchedule.WorkingDay;
            scheduleToUpdate.Shift = DoctorSchedule.Shift;
            scheduleToUpdate.ReplacementDoctor = DoctorSchedule.ReplacementDoctor;

            // Lưu lại thay đổi vào cơ sở dữ liệu
            await _context.SaveChangesAsync();

            return RedirectToPage("./DoctorSchedule"); // Điều hướng đến trang danh sách lịch bác sĩ
        }
    }
}
