using System;
using System.Collections.Generic;
using KoiManagement.WebApplication.Models;

namespace KoiManagement.WebApplication.Services
{
    public class ServiceManager
    {
        private List<PetService> _services;
        private EmailService _emailService;

        public ServiceManager()
        {
            _services = new List<PetService>();
            _emailService = new EmailService();
        }

        public void AddService(PetService service)
        {
            _services.Add(service);
        }

        public List<PetService> GetServiceHistory()
        {
            return _services;
        }

        public void SendReminder(string email, string message)
        {
            _emailService.SendEmail(email, "Nhắc nhở dịch vụ", message);
        }
    }
}
