using Attendance.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace Attendance.Repository;

public class AttendanceDbContext(DbContextOptions<AttendanceDbContext> options) : DbContext(options)
{
    public DbSet<Models.Attendance> Attendances { get; set; }
    public DbSet<LeaveRecord> LeaveRecords { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Attendance Entity Configuration
        modelBuilder.Entity<Models.Attendance>(entity =>
        {
            entity.HasKey(a => a.AttendanceId);
            entity.Property(a => a.EmployeeId).IsRequired();
            entity.Property(a => a.Date).IsRequired();
            entity.Property(a => a.CheckInTime).IsRequired();
            entity.Property(a => a.CheckOutTime).IsRequired();
            entity.Property(a => a.TotalHoursWorked).IsRequired();
        });

        // LeaveRecord Entity Configuration
        modelBuilder.Entity<LeaveRecord>(entity =>
        {
            entity.HasKey(l => l.LeaveRecordId);
            entity.Property(l => l.EmployeeId).IsRequired();
            entity.Property(l => l.StartDate).IsRequired();
            entity.Property(l => l.EndDate).IsRequired();
            entity.Property(l => l.LeaveType).IsRequired().HasMaxLength(50);
            entity.Property(l => l.Reason).IsRequired().HasMaxLength(500);
            entity.Property(l => l.IsApproved).IsRequired();
        });
    }
}