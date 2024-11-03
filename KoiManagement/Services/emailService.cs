namespace KoiManagement.WebApplication.Services
{
    public class EmailService
    {
        public void SendEmail(string to, string subject, string body)
        {
            Console.WriteLine($"Gửi email đến {to} với tiêu đề: {subject} và nội dung: {body}");
        }
    }
}
