using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EFcoreEg.Models;

public partial class FisbankDbContext : DbContext
{
    public FisbankDbContext()
    {
    }

    public FisbankDbContext(DbContextOptions<FisbankDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Usertbl> Usertbls { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=FISBankDB;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.Did).HasName("PK__Departme__C0312218A76455AF");

            entity.ToTable("Department");

            entity.Property(e => e.Did).ValueGeneratedNever();
            entity.Property(e => e.Dname)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Location)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("location");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Eid).HasName("PK__Employee__C1971B5327F2A862");

            entity.ToTable("Employee", tb => tb.HasTrigger("t1"));

            entity.HasIndex(e => e.Ename, "enameidx");

            entity.Property(e => e.Eid).ValueGeneratedNever();
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("('Mumbai')");
            entity.Property(e => e.Doj).HasColumnType("date");
            entity.Property(e => e.Ename)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Dept).WithMany(p => p.Employees)
                .HasForeignKey(d => d.Deptid)
                .HasConstraintName("FK__Employee__Deptid__25869641");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Sid).HasName("PK__student__DDDFDD36149CB716");

            entity.ToTable("student");

            entity.HasIndex(e => e.Email, "UQ__student__AB6E61648CFF0472").IsUnique();

            entity.Property(e => e.Sid).HasColumnName("sid");
            entity.Property(e => e.Doj)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date")
                .HasColumnName("doj");
            entity.Property(e => e.Email)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Marks).HasColumnName("marks");
            entity.Property(e => e.Sname)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("sname");
            entity.Property(e => e.Subject)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("subject");
        });

        modelBuilder.Entity<Usertbl>(entity =>
        {
            entity.HasKey(e => e.Email).HasName("PK__Usertbl__A9D1053578644B0C");

            entity.ToTable("Usertbl");

            entity.Property(e => e.Email)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Username)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
