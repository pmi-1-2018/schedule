using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using schedule.Entities;

namespace schedule
{
    public partial class ScheduleDbContext : DbContext
    {
        public ScheduleDbContext()
        {
           
        }

        public ScheduleDbContext(DbContextOptions<ScheduleDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<GroupSubject> GroupSubjects { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<TeacherSubject> TeacherSubjects { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseLazyLoadingProxies().UseNpgsql("Host=localhost;Port=5432;Database=scheduledb;Username=postgres;Password=Andriy1986");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Class>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Class)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Classes_GroupId_fkey");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.Class)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Classes_RoomId_fkey");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Class)
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Classes_SubjectId_fkey");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.Class)
                    .HasForeignKey(d => d.TeacherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Classes_TeacherId_fkey");
            });

            modelBuilder.Entity<GroupSubject>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.GroupSubject)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("GroupSubjects_GroupId_fkey");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.GroupSubject)
                    .HasForeignKey(d => d.SubjectId)
                    .HasConstraintName("GroupSubjects_SubjectId_fkey");
            });

            modelBuilder.Entity<Group>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<TeacherSubject>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.TeacherSubject)
                    .HasForeignKey(d => d.SubjectId)
                    .HasConstraintName("TeacherSubjects_SubjectId_fkey");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.TeacherSubject)
                    .HasForeignKey(d => d.TeacherId)
                    .HasConstraintName("TeacherSubjects_TeacherId_fkey");
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
