using KoiManagement.Repositories.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KoiManagement.Repositories.Interfaces
{
    public interface IAppointmentService
    {
        Task<List<Appointment>> GetAllAsync();
        Task<Appointment?> GetByIdAsync(string id);
        Task AddAsync(Appointment appointment);
        Task UpdateAsync(Appointment appointment);
        Task DeleteAsync(string appointmentId);
    }
}
