using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Thêm dịch vụ Session
builder.Services.AddSession();

// Thêm dịch vụ Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
})
.AddCookie()
.AddGoogle(GoogleDefaults.AuthenticationScheme, options =>
{
    options.ClientId = builder.Configuration["GoogleKeys:ClientId"];
    options.ClientSecret = builder.Configuration["GoogleKeys:ClientSecret"];
    options.CallbackPath = "/signin-google"; // URI này phải trùng với URI trong Google Cloud Console
    options.Scope.Add("profile"); // Đảm bảo yêu cầu quyền truy cập vào thông tin hồ sơ
});

// Thêm các dịch vụ vào container
builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Sử dụng Session
app.UseSession();

// Cấu hình pipeline yêu cầu HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error"); // Chỉ định trang lỗi
}

app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication(); // Đảm bảo gọi UseAuthentication trước UseAuthorization
app.UseAuthorization();

// Định tuyến
app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
