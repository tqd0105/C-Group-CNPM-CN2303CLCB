using Microsoft.EntityFrameworkCore;
using KoiManagement.Repositories.Models;

namespace KoiManagement.Repositories
{
    public class AppDbContext : DbContext
    {
       
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}
