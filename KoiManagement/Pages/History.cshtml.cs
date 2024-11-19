using KoiManagement.WebApplication.Data;
using KoiManagement.WebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace KoiManagement.WebApplication.Pages
{
    public class HistoryModel : PageModel
    {
        private readonly KoiManagementWebApplicationContext _context;

        public HistoryModel(KoiManagementWebApplicationContext context)
        {
            _context = context;
        }

        public IList<BookingSchedule> BookingSchedule { get; set; } = default!;

        public async Task OnGetAsync(string SearchString, DateTime? SearchDate)
        {
            var schedules = from b in _context.BookingSchedule
                            select b;

            if (!String.IsNullOrEmpty(SearchString))
            {
                schedules = schedules.Where(s =>
                    s.koi_name!.Contains(SearchString) ||
                    s.name!.Contains(SearchString) ||
                    s.phone!.Contains(SearchString) ||
                    s.email!.Contains(SearchString) ||
                    s.vets_name!.Contains(SearchString) ||
                    s.description!.Contains(SearchString));

            }

            if (SearchDate.HasValue)
            {
                schedules = schedules.Where(s => s.Booking_Date.Date == SearchDate.Value.Date);
            }


            BookingSchedule = await schedules.ToListAsync();
        }
    }
}
