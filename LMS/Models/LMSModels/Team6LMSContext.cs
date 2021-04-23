using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LMS.Models.LMSModels
{
    public partial class Team6LMSContext : DbContext
    {
        public Team6LMSContext()
        {
        }

        public Team6LMSContext(DbContextOptions<Team6LMSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Administrators> Administrators { get; set; }
        public virtual DbSet<AssignmentCategories> AssignmentCategories { get; set; }
        public virtual DbSet<Assignments> Assignments { get; set; }
        public virtual DbSet<Classes> Classes { get; set; }
        public virtual DbSet<Courses> Courses { get; set; }
        public virtual DbSet<Departments> Departments { get; set; }
        public virtual DbSet<Enrolled> Enrolled { get; set; }
        public virtual DbSet<Professors> Professors { get; set; }
        public virtual DbSet<Students> Students { get; set; }
        public virtual DbSet<Submissions> Submissions { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("Server=atr.eng.utah.edu;User Id=u1200824;Password=1stdogPixie;Database=Team6LMS");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Administrators>(entity =>
            {
                entity.HasKey(e => e.UId)
                    .HasName("PRIMARY");

                entity.Property(e => e.UId)
                    .HasColumnName("uID")
                    .HasColumnType("char(8)");

                entity.HasOne(d => d.U)
                    .WithOne(p => p.Administrators)
                    .HasForeignKey<Administrators>(d => d.UId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Administrators_ibfk_1");
            });

            modelBuilder.Entity<AssignmentCategories>(entity =>
            {
                entity.HasKey(e => e.AcId)
                    .HasName("PRIMARY");

                entity.HasIndex(e => new { e.ClsId, e.Name })
                    .HasName("clsID")
                    .IsUnique();

                entity.Property(e => e.AcId)
                    .HasColumnName("acID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ClsId)
                    .HasColumnName("clsID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(100)");

                entity.HasOne(d => d.Cls)
                    .WithMany(p => p.AssignmentCategories)
                    .HasForeignKey(d => d.ClsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("AssignmentCategories_ibfk_1");
            });

            modelBuilder.Entity<Assignments>(entity =>
            {
                entity.HasKey(e => e.AId)
                    .HasName("PRIMARY");

                entity.HasIndex(e => new { e.AcId, e.Name })
                    .HasName("acID")
                    .IsUnique();

                entity.Property(e => e.AId)
                    .HasColumnName("aID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AcId)
                    .HasColumnName("acID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Contents)
                    .IsRequired()
                    .HasColumnType("varchar(8192)");

                entity.Property(e => e.Due).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(100)");

                entity.HasOne(d => d.Ac)
                    .WithMany(p => p.Assignments)
                    .HasForeignKey(d => d.AcId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Assignments_ibfk_1");
            });

            modelBuilder.Entity<Classes>(entity =>
            {
                entity.HasKey(e => e.ClsId)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.CId)
                    .HasName("cID");

                entity.HasIndex(e => e.PId)
                    .HasName("pID");

                entity.HasIndex(e => new { e.Year, e.CId })
                    .HasName("Semester")
                    .IsUnique();

                entity.Property(e => e.ClsId)
                    .HasColumnName("clsID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CId)
                    .HasColumnName("cID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.End).HasColumnType("time");

                entity.Property(e => e.Loc)
                    .IsRequired()
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.PId)
                    .IsRequired()
                    .HasColumnName("pID")
                    .HasColumnType("char(8)");

                entity.Property(e => e.Season).HasColumnType("varchar(10)");

                entity.Property(e => e.Start).HasColumnType("time");

                entity.HasOne(d => d.C)
                    .WithMany(p => p.Classes)
                    .HasForeignKey(d => d.CId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Classes_ibfk_2");

                entity.HasOne(d => d.P)
                    .WithMany(p => p.Classes)
                    .HasForeignKey(d => d.PId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Classes_ibfk_1");
            });

            modelBuilder.Entity<Courses>(entity =>
            {
                entity.HasKey(e => e.CId)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.Subject)
                    .HasName("Subject");

                entity.HasIndex(e => new { e.Num, e.Subject })
                    .HasName("Num")
                    .IsUnique();

                entity.Property(e => e.CId)
                    .HasColumnName("cID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name).HasColumnType("varchar(100)");

                entity.Property(e => e.Num).HasColumnType("int(11)");

                entity.Property(e => e.Subject).HasColumnType("varchar(4)");

                entity.HasOne(d => d.SubjectNavigation)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.Subject)
                    .HasConstraintName("Courses_ibfk_1");
            });

            modelBuilder.Entity<Departments>(entity =>
            {
                entity.HasKey(e => e.Subject)
                    .HasName("PRIMARY");

                entity.Property(e => e.Subject).HasColumnType("varchar(4)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(100)");
            });

            modelBuilder.Entity<Enrolled>(entity =>
            {
                entity.HasKey(e => new { e.UId, e.ClsId })
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.ClsId)
                    .HasName("clsID");

                entity.Property(e => e.UId)
                    .HasColumnName("uID")
                    .HasColumnType("char(8)");

                entity.Property(e => e.ClsId)
                    .HasColumnName("clsID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Grade)
                    .IsRequired()
                    .HasColumnType("varchar(2)");

                entity.HasOne(d => d.Cls)
                    .WithMany(p => p.Enrolled)
                    .HasForeignKey(d => d.ClsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Enrolled_ibfk_2");

                entity.HasOne(d => d.U)
                    .WithMany(p => p.Enrolled)
                    .HasForeignKey(d => d.UId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Enrolled_ibfk_1");
            });

            modelBuilder.Entity<Professors>(entity =>
            {
                entity.HasKey(e => e.UId)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.Subject)
                    .HasName("Subject");

                entity.Property(e => e.UId)
                    .HasColumnName("uID")
                    .HasColumnType("char(8)");

                entity.Property(e => e.Subject)
                    .IsRequired()
                    .HasColumnType("varchar(4)");

                entity.HasOne(d => d.SubjectNavigation)
                    .WithMany(p => p.Professors)
                    .HasForeignKey(d => d.Subject)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Professors_ibfk_1");

                entity.HasOne(d => d.U)
                    .WithOne(p => p.Professors)
                    .HasForeignKey<Professors>(d => d.UId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Professors_ibfk_2");
            });

            modelBuilder.Entity<Students>(entity =>
            {
                entity.HasKey(e => e.UId)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.Subject)
                    .HasName("Subject");

                entity.Property(e => e.UId)
                    .HasColumnName("uID")
                    .HasColumnType("char(8)");

                entity.Property(e => e.Subject)
                    .IsRequired()
                    .HasColumnType("varchar(4)");

                entity.HasOne(d => d.SubjectNavigation)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.Subject)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Students_ibfk_1");

                entity.HasOne(d => d.U)
                    .WithOne(p => p.Students)
                    .HasForeignKey<Students>(d => d.UId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Students_ibfk_2");
            });

            modelBuilder.Entity<Submissions>(entity =>
            {
                entity.HasKey(e => new { e.UId, e.AId })
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.AId)
                    .HasName("aID");

                entity.Property(e => e.UId)
                    .HasColumnName("uID")
                    .HasColumnType("char(8)");

                entity.Property(e => e.AId)
                    .HasColumnName("aID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Contents)
                    .IsRequired()
                    .HasColumnType("varchar(8192)");

                entity.Property(e => e.Time).HasColumnType("datetime");

                entity.HasOne(d => d.A)
                    .WithMany(p => p.Submissions)
                    .HasForeignKey(d => d.AId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Submissions_ibfk_2");

                entity.HasOne(d => d.U)
                    .WithMany(p => p.Submissions)
                    .HasForeignKey(d => d.UId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Submissions_ibfk_1");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UId)
                    .HasName("PRIMARY");

                entity.Property(e => e.UId)
                    .HasColumnName("uID")
                    .HasColumnType("char(8)");

                entity.Property(e => e.Dob)
                    .HasColumnName("DOB")
                    .HasColumnType("date");

                entity.Property(e => e.FName)
                    .IsRequired()
                    .HasColumnName("fName")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.LName)
                    .IsRequired()
                    .HasColumnName("lName")
                    .HasColumnType("varchar(100)");
            });
        }
    }
}
