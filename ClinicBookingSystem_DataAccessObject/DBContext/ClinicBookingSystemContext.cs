using ClinicBookingSystem_BusinessObject.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicBookingSystem_DataAcessObject.DBContext
{
    public class ClinicBookingSystemContext : DbContext
    {
        public ClinicBookingSystemContext(DbContextOptions<ClinicBookingSystemContext> options): base(options)
        { }
        public DbSet<User> Users => Set<User>();
        public DbSet<Role> Roles => Set<Role>();
        public DbSet<Appointment> Appointments => Set<Appointment>();
        public DbSet<Service> Services => Set<Service>();
        public DbSet<Specification> Specifications => Set<Specification>();
        public DbSet<Salary> Salaries => Set<Salary>();
        public DbSet<Clinic> Clinics => Set<Clinic>();
        public DbSet<Relative> Relatives => Set<Relative>();
        public DbSet<Claim> Claims => Set<Claim>();
        public DbSet<Slot> Slots => Set<Slot>();
        public DbSet<Application> Applications => Set<Application>();
        public DbSet<Result> Results => Set<Result>();
        public DbSet<MedicalRecord> MedicalRecords => Set<MedicalRecord>();
        public DbSet<Medicine> Medicines => Set<Medicine>();
        public DbSet<Transaction> Transactions => Set<Transaction>();
        public DbSet<Billing> Billings => Set<Billing>();
        public DbSet<Order> Orders => Set<Order>();
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
            .HasOne(o => o.User)
            .WithMany(u => u.Orders)
            .HasForeignKey(o => o.Id)
            .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);
        }
    }
}
