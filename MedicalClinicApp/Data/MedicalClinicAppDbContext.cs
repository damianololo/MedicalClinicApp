using MedicalClinicApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace MedicalClinicApp.Data
{
    public class MedicalClinicAppDbContext :DbContext
    {
        public DbSet<Employee> Employees => Set<Employee>();

        public DbSet<Patient> Patients => Set<Patient>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseInMemoryDatabase("StorageAppDb");
        }
    }
}
