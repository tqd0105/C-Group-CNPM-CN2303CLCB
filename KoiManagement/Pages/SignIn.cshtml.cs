using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using KoiManagement.WebApplication.Data;
using KoiManagement.WebApplication.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace KoiManagement.WebApplication.Pages
{
    public class SignInModel : PageModel
    {
        private readonly KoiManagementWebApplicationContext _context;

        public SignInModel(KoiManagementWebApplicationContext context)
        {
            _context = context;
        }

        [BindProperty]
        public string Username { get; set; }
        [BindProperty]
        public string Password { get; set; }

        public string Message { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
            {
                Message = "Please enter both username and password.";
                return Page();
            }

            // Kiểm tra xem có tài khoản trùng khớp không
            var loginAccount = await _context.LoginAccount.FirstOrDefaultAsync(a => a.username == Username && a.password == Password);

            if (loginAccount == null)
            {
                Message = "Invalid username or password.";
                return Page();
            }

            // Nếu đăng nhập thành công, tạo cookie và chuyển hướng
            var claims = new List<Claim>
    {
        new Claim(ClaimTypes.Name, Username)
    };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);

            return RedirectToPage("/Index"); // Chuyển đến trang chính sau khi đăng nhập
        }

    }
}
