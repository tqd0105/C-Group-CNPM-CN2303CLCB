using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KoiManagement.WebApplication.Data;
using KoiManagement.WebApplication.Models;

namespace KoiManagement.WebApplication.Pages
{
    public class Booking : PageModel
    {
        private readonly KoiManagementWebApplicationContext _context;

        public Booking(KoiManagementWebApplicationContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public BookingSchedule BookingSchedule { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.BookingSchedule.Add(BookingSchedule);
            await _context.SaveChangesAsync();

            return RedirectToPage("/History");
        }
    }
}
