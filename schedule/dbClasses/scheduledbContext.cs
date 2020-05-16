using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace schedule
{
    public partial class scheduledbContext : DbContext
    {
        public scheduledbContext()
        {
        }

        public scheduledbContext(DbContextOptions<scheduledbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Classes> Classes { get; set; }
        public virtual DbSet<GroupSubjects> GroupSubjects { get; set; }
        public virtual DbSet<Groups> Groups { get; set; }
        public virtual DbSet<Rooms> Rooms { get; set; }
        public virtual DbSet<Subjects> Subjects { get; set; }
        public virtual DbSet<TeacherSubjects> TeacherSubjects { get; set; }
        public virtual DbSet<Teachers> Teachers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=scheduledb;Username=postgres;Password=1111");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Classes>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Classes)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Classes_GroupId_fkey");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.Classes)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Classes_RoomId_fkey");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Classes)
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Classes_SubjectId_fkey");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.Classes)
                    .HasForeignKey(d => d.TeacherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Classes_TeacherId_fkey");
            });

            modelBuilder.Entity<GroupSubjects>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.GroupSubjects)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("GroupSubjects_GroupId_fkey");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.GroupSubjects)
                    .HasForeignKey(d => d.SubjectId)
                    .HasConstraintName("GroupSubjects_SubjectId_fkey");
            });

            modelBuilder.Entity<Groups>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Rooms>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Subjects>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<TeacherSubjects>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.TeacherSubjects)
                    .HasForeignKey(d => d.SubjectId)
                    .HasConstraintName("TeacherSubjects_SubjectId_fkey");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.TeacherSubjects)
                    .HasForeignKey(d => d.TeacherId)
                    .HasConstraintName("TeacherSubjects_TeacherId_fkey");
            });

            modelBuilder.Entity<Teachers>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
