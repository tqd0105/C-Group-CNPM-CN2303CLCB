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
    public class DetailModel : PageModel
    {
        private readonly KoiManagementWebApplicationContext _context;

        public DetailModel(KoiManagementWebApplicationContext context)
        {
            _context = context;
        }

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
    }
}
