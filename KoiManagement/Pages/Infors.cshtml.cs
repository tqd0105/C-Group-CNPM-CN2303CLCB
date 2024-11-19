using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiManagement.WebApplication.Data;
using KoiManagement.WebApplication.Models;

namespace KoiManagement.WebApplication.Pages
{
    public class InforsModel : PageModel
    {
        private readonly KoiManagementWebApplicationContext _context;

        public InforsModel(KoiManagementWebApplicationContext context)
        {
            _context = context;
        }

        public BookingSchedule BookingSchedule { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookingschedule = await _context.BookingSchedule.FirstOrDefaultAsync(m => m.Id == id);
            if (bookingschedule == null)
            {
                return NotFound();
            }
            else
            {
                BookingSchedule = bookingschedule;
            }
            return Page();
        }
    }
}
