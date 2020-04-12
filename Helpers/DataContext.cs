using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebApi.Entities;

namespace WebApi.Helpers
{
    public class DataContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sql server database
            options.UseSqlServer(Configuration.GetConnectionString("WebApiDatabase"));
        }

        public DbSet<User> Users { get; set; }
        // public DbSet<TimeSlot> TimeSlots { get; set; }
        // public DbSet<Clinic> Clinics { get; set; }
        // public DbSet<Intervention> Interventions { get; set; }
        // public DbSet<Status> Status { get; set; }
        // public DbSet<Patient> Patients { get; set; }
        // public DbSet<Appointment> Appointments { get; set; }

    }
}