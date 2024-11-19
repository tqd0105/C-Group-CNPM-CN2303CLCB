using KoiManagement.WebApplication.Data;
using KoiManagement.WebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace KoiManagement.WebApplication.Pages
{
    public class DoctorScheduleModel : PageModel
    {
        private readonly KoiManagementWebApplicationContext _context;

        public DoctorScheduleModel(KoiManagementWebApplicationContext context)
        {
            _context = context;
        }

        [BindProperty]
        public DoctorSchedule DoctorSchedule { get; set; }

        public List<DoctorSchedule> Schedule { get; set; } = new List<DoctorSchedule>();

        // Phương thức OnGetAsync cho phép lọc theo các tham số truyền vào
        public async Task OnGetAsync(string doctorName, DateTime? workingDay, string shift)
        {
            // Khởi tạo truy vấn với tất cả lịch bác sĩ
            var schedules = from s in _context.DoctorSchedule
                            select s;

            // Lọc theo tên bác sĩ nếu có
            if (!string.IsNullOrEmpty(doctorName))
            {
                schedules = schedules.Where(s => s.DoctorName.Contains(doctorName));
            }

            // Lọc theo ngày làm việc nếu có
            if (workingDay.HasValue)
            {
                schedules = schedules.Where(s => s.WorkingDay.Date == workingDay.Value.Date);
            }

            // Lọc theo ca làm việc nếu có
            if (!string.IsNullOrEmpty(shift))
            {
                schedules = schedules.Where(s => s.Shift.Contains(shift));
            }

            // Lấy tất cả các lịch bác sĩ theo các điều kiện lọc
            Schedule = await schedules.ToListAsync();
        }

        // Phương thức OnPostAsync để lưu lịch bác sĩ mới
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                // Thêm lịch bác sĩ mới vào cơ sở dữ liệu
                _context.DoctorSchedule.Add(DoctorSchedule);
                await _context.SaveChangesAsync();
                return RedirectToPage(); // Quay lại trang sau khi thêm thành công
            }
            return Page(); // Trả về trang hiện tại nếu có lỗi hợp lệ
        }

        // Phương thức OnPostDeleteAsync để xóa lịch bác sĩ
        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            // Tìm lịch bác sĩ theo ID
            var schedule = await _context.DoctorSchedule.FindAsync(id);
            if (schedule != null)
            {
                // Xóa lịch bác sĩ nếu tồn tại
                _context.DoctorSchedule.Remove(schedule);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage(); // Quay lại trang sau khi xóa thành công
        }
    }
}
