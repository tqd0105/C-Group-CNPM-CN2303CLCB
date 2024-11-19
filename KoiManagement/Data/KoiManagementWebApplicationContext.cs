using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KoiManagement.WebApplication.Models;

namespace KoiManagement.WebApplication.Data
{
    public class KoiManagementWebApplicationContext : DbContext
    {
        public KoiManagementWebApplicationContext (DbContextOptions<KoiManagementWebApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<KoiManagement.WebApplication.Models.BookingSchedule> BookingSchedule { get; set; } = default!;
        public DbSet<KoiManagement.WebApplication.Models.LoginAccount> LoginAccount { get; set; } = default!;
        public DbSet<KoiManagement.WebApplication.Models.DoctorSchedule> DoctorSchedule { get; set; } = default!;
        public DbSet<KoiManagement.WebApplication.Models.TreatmentSchedule> TreatmentSchedule { get; set; } = default!;
    }
}
