using Microsoft.EntityFrameworkCore;
using Payroll.Repository.Models;

namespace Payroll.Repository;

public class PayrollDbContext(DbContextOptions<PayrollDbContext> options) : DbContext(options)
{
    public DbSet<Models.Payroll> Payrolls { get; init; }
    public DbSet<Salary> Salaries { get; init; }
    public DbSet<Deduction> Deductions { get; init; }
    public DbSet<Employee> Employees { get; init; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Models.Payroll>(entity =>
        {
            entity.HasKey(p => p.PayrollId);

            entity.Property(p => p.GrossSalary)
                .IsRequired()
                .HasPrecision(18, 2);

            entity.Property(p => p.NetSalary)
                .IsRequired()
                .HasPrecision(18, 2);

            entity.Property(p => p.PayrollDate)
                .IsRequired()
                .HasColumnType("date");

            entity.HasMany(p => p.Deductions)
                .WithOne(d => d.Payroll)
                .HasForeignKey(d => d.PayrollId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Salary>(entity =>
        {
            entity.HasKey(s => s.SalaryId);

            entity.Property(s => s.BaseSalary)
                .IsRequired()
                .HasPrecision(18, 2);

            entity.Property(s => s.EffectiveDate)
                .IsRequired()
                .HasColumnType("date");

            entity.HasIndex(s => new { s.EmployeeId, s.EffectiveDate })
                .IsUnique();
        });

        modelBuilder.Entity<Deduction>(entity =>
        {
            entity.HasKey(d => d.DeductionId);

            entity.Property(d => d.Description)
                .IsRequired()
                .HasMaxLength(250);

            entity.Property(d => d.Amount)
                .IsRequired()
                .HasPrecision(18, 2);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.PrimaryId);
            entity.Property(e => e.Id)
                .IsRequired();
        });
    }
}