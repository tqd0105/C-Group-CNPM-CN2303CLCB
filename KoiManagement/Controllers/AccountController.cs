using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

public class AccountController : Controller
{
    [HttpGet]
    public IActionResult SignInWithGoogle(string returnUrl = "/")
    {
        var redirectUrl = Url.Action("GoogleResponse", "Account", new { returnUrl });
        var properties = new AuthenticationProperties { RedirectUri = redirectUrl };
        return Challenge(properties, GoogleDefaults.AuthenticationScheme);
    }

    [HttpGet]
    public async Task<IActionResult> GoogleResponse(string returnUrl = "/")
    {
        var result = await HttpContext.AuthenticateAsync(GoogleDefaults.AuthenticationScheme);

        if (!result.Succeeded) // Kiểm tra xác thực thành công
            return RedirectToAction("Login", "Login");

        var claimsIdentity = result.Principal.Identity as ClaimsIdentity;

        // Lấy URL ảnh đại diện từ claim "picture"
        var avatarUrl = claimsIdentity?.FindFirst("picture")?.Value;

        // Lưu URL vào session
        if (avatarUrl != null)
        {
            HttpContext.Session.SetString("AvatarUrl", avatarUrl);
        }

        return LocalRedirect(returnUrl);
    }
}
