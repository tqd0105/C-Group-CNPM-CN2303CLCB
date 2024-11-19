using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using KoiManagement.WebApplication.Data;
using Microsoft.AspNetCore.Identity;
using KoiManagement.Repositories.Interfaces;
using KoiManagement.Repositories.Repositories;
using KoiManagement.Repositories;
using KoiManagement.Services.Interfaces;
using KoiManagement.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
builder.Configuration.AddEnvironmentVariables();

var connectionString = builder.Configuration.GetConnectionString("KoiManagementWebApplicationContext");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

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
    options.SaveTokens = true;
    // Thêm tham số buộc chọn lại tài khoản
    options.Events.OnRedirectToAuthorizationEndpoint = context =>
    {
        context.Response.Redirect(context.RedirectUri + "&prompt=select_account");
        return Task.CompletedTask;
    };

});

var connectionToString = builder.Configuration.GetConnectionString("KoiManagementWebApplicationContext");
Console.WriteLine($"KoiManagementWebApplicationContext: {connectionToString}");

if (string.IsNullOrEmpty(connectionToString))
{
    throw new InvalidOperationException("Connection string 'KoiManagementWebApplicationContext' not found.");
}

builder.Services.AddDbContext<KoiManagementWebApplicationContext>(options =>
    options.UseSqlServer(connectionToString));


// Đăng ký các dịch vụ và repository cho Dependency Injection

builder.Services.AddScoped<IRatingRepository, RatingRepository>();
builder.Services.AddScoped<IRatingService, RatingService>();

builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
builder.Services.AddScoped<IAppointmentService, AppointmentService>();
builder.Services.AddControllers();
builder.Services.AddRazorPages();

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
