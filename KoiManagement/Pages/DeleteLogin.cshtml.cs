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
    public class DeleteLogins : PageModel
    {
        private readonly KoiManagementWebApplicationContext _context;

        public DeleteLogins(KoiManagementWebApplicationContext context)
        {
            _context = context;
        }

        [BindProperty]
        public LoginAccount LoginAccount { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string? username)
        {
            if (username == null)
            {
                return NotFound();
            }

            var loginaccount = await _context.LoginAccount.FirstOrDefaultAsync(m => m.username == username);

            if (loginaccount == null)
            {
                return NotFound();
            }
            else
            {
                LoginAccount = loginaccount;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loginaccount = await _context.LoginAccount.FindAsync(id);
            if (loginaccount != null)
            {
                LoginAccount = loginaccount;
                _context.LoginAccount.Remove(LoginAccount);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
