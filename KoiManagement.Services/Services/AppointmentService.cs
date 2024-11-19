using KoiManagement.Repositories.Interfaces;
using KoiManagement.Repositories.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KoiManagement.Repositories.Repositories
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public AppointmentService(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        // Lấy tất cả các cuộc hẹn
        public async Task<List<Appointment>> GetAllAsync()
        {
            return await _appointmentRepository.GetAllAppointmentsAsync();
        }

        // Lấy thông tin cuộc hẹn theo ID
        public async Task<Appointment?> GetByIdAsync(string id)
        {
            return await _appointmentRepository.GetAppointmentByIdAsync(id);
        }

        // Thêm mới một cuộc hẹn
        public async Task AddAsync(Appointment appointment)
        {
            await _appointmentRepository.AddAppointmentAsync(appointment);
        }

        // Cập nhật thông tin cuộc hẹn
        public async Task UpdateAsync(Appointment appointment)
        {
            await _appointmentRepository.UpdateAppointmentAsync(appointment);
        }

        // Xóa cuộc hẹn theo ID
        public async Task DeleteAsync(string appointmentId)
        {
            await _appointmentRepository.DeleteAppointmentAsync(appointmentId);
        }
    }
}
