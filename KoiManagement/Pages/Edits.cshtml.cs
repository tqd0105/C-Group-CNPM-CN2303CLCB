using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KoiManagement.WebApplication.Data;
using KoiManagement.WebApplication.Models;

namespace KoiManagement.WebApplication.Pages
{
    public class EditsModel : PageModel
    {
        private readonly KoiManagementWebApplicationContext _context;

        public EditsModel(KoiManagementWebApplicationContext context)
        {
            _context = context;
        }

        [BindProperty]
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
            BookingSchedule = bookingschedule;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(BookingSchedule).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookingScheduleExists(BookingSchedule.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./History");
        }

        private bool BookingScheduleExists(int id)
        {
            return _context.BookingSchedule.Any(e => e.Id == id);
        }
    }
}
