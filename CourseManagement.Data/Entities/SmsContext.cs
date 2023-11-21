using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CourseManagement.Data.Entities;

public partial class SmsContext : DbContext
{
    public SmsContext()
    {
    }

    public SmsContext(DbContextOptions<SmsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblCourse> TblCourses { get; set; }

    public virtual DbSet<TblStudent> TblStudents { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=SMS;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblCourse>(entity =>
        {
            entity.HasKey(e => e.CourseId);

            entity.ToTable("tblCourse");

            entity.Property(e => e.CourseId).ValueGeneratedNever();
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblStudent>(entity =>
        {
            entity.HasKey(e => e.StudentId);

            entity.ToTable("tblStudent");

            entity.Property(e => e.StudentId).ValueGeneratedNever();
            entity.Property(e => e.Courses)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(15)
                .IsUnicode(false);

            entity.HasOne(d => d.Course).WithMany(p => p.TblStudents)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK_tblStudent_tblCourse");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
