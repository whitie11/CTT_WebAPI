using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApi.Entities2
{
    public partial class CTT_DbContext : DbContext
    {
        public CTT_DbContext()
        {
        }

        public CTT_DbContext(DbContextOptions<CTT_DbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Appts> Appts { get; set; }
        public virtual DbSet<Clinics> Clinics { get; set; }
        public virtual DbSet<Localities> Localities { get; set; }
        public virtual DbSet<Patients> Patients { get; set; }
        public virtual DbSet<Stages> Stages { get; set; }
        public virtual DbSet<TimeSlots> TimeSlots { get; set; }
        public virtual DbSet<Types> Types { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=ctt-dbs.database.windows.net;Database=CTT_Db;Persist Security Info=False;User ID=Whitie11;Password=C@sper123;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appts>(entity =>
            {
                entity.HasKey(e => e.ApptId);

                entity.HasIndex(e => e.ClinicId);

                entity.HasIndex(e => e.PatientId);

                entity.HasIndex(e => e.StageId);

                entity.HasIndex(e => e.TimeSlotId);

                entity.HasIndex(e => e.TypeId);

                entity.HasOne(d => d.Clinic)
                    .WithMany(p => p.Appts)
                    .HasForeignKey(d => d.ClinicId);

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Appts)
                    .HasForeignKey(d => d.PatientId);

                entity.HasOne(d => d.Stage)
                    .WithMany(p => p.Appts)
                    .HasForeignKey(d => d.StageId);

                entity.HasOne(d => d.TimeSlot)
                    .WithMany(p => p.Appts)
                    .HasForeignKey(d => d.TimeSlotId);

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Appts)
                    .HasForeignKey(d => d.TypeId);
            });

            modelBuilder.Entity<Clinics>(entity =>
            {
                entity.HasKey(e => e.ClinicId);
            });

            modelBuilder.Entity<Localities>(entity =>
            {
                entity.HasKey(e => e.LocalityId);
            });

            modelBuilder.Entity<Patients>(entity =>
            {
                entity.HasKey(e => e.PatientId);

                entity.HasIndex(e => e.LocalityId);

                entity.Property(e => e.Cpmsno).HasColumnName("CPMSno");

                entity.Property(e => e.IsOpen)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.Nhsno).HasColumnName("NHSno");

                entity.HasOne(d => d.Locality)
                    .WithMany(p => p.Patients)
                    .HasForeignKey(d => d.LocalityId);
            });

            modelBuilder.Entity<Stages>(entity =>
            {
                entity.HasKey(e => e.StageId);
            });

            modelBuilder.Entity<TimeSlots>(entity =>
            {
                entity.HasKey(e => e.TimeSlotId);
            });

            modelBuilder.Entity<Types>(entity =>
            {
                entity.HasKey(e => e.TypeId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
