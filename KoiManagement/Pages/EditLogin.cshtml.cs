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
    public class EditModels : PageModel
    {
        private readonly KoiManagementWebApplicationContext _context;

        public EditModels(KoiManagementWebApplicationContext context)
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
            LoginAccount = loginaccount;
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

            _context.Attach(LoginAccount).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoginAccountExists(LoginAccount.username))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Page();
        }

        private bool LoginAccountExists(string username)
        {
            return _context.LoginAccount.Any(e => e.username == username);
        }
    }
}
