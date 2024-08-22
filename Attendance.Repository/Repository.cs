using Attendance.Repository.Abstractions;
using Attendance.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace Attendance.Repository;

public class Repository(AttendanceDbContext dbContext) : IRepository
{
    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task CreateAttendance(Models.Attendance attendance, CancellationToken cancellationToken = default)
    {
        await dbContext.Attendances.AddAsync(attendance, cancellationToken);
    }

    public async Task<Models.Attendance?> GetAttendanceById(int attendanceId,
        CancellationToken cancellationToken = default)
    {
        return await dbContext.Attendances.FindAsync([attendanceId], cancellationToken);
    }

    public async Task<IEnumerable<Models.Attendance>> GetAttendances(CancellationToken cancellationToken = default)
    {
        return await dbContext.Attendances.ToListAsync(cancellationToken);
    }

    public async Task<bool> DeleteAttendance(int attendanceId, CancellationToken cancellationToken = default)
    {
        var attendance = await GetAttendanceById(attendanceId, cancellationToken);
        if (attendance == null) return false;
        dbContext.Attendances.Remove(attendance);
        return true;
    }

    public async Task CreateLeaveRecord(LeaveRecord leaveRecord, CancellationToken cancellationToken = default)
    {
        await dbContext.LeaveRecords.AddAsync(leaveRecord, cancellationToken);
    }

    public async Task<LeaveRecord?> GetLeaveRecordById(int leaveRecordId, CancellationToken cancellationToken = default)
    {
        return await dbContext.LeaveRecords.FindAsync([leaveRecordId], cancellationToken);
    }

    public async Task<IEnumerable<LeaveRecord>> GetLeaveRecords(CancellationToken cancellationToken = default)
    {
        return await dbContext.LeaveRecords.ToListAsync(cancellationToken);
    }

    public async Task<bool> DeleteLeaveRecord(int leaveRecordId, CancellationToken cancellationToken = default)
    {
        var leaveRecord = await GetLeaveRecordById(leaveRecordId, cancellationToken);
        if (leaveRecord == null) return false;
        dbContext.LeaveRecords.Remove(leaveRecord);
        return true;
    }

    public async Task<IEnumerable<Models.Attendance>> GetAttendancesByEmployeeId(int employeeId,
        CancellationToken cancellationToken = default)
    {
        return await dbContext.Attendances.Where(attendance => attendance.EmployeeId == employeeId)
            .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<LeaveRecord>> GetLeaveRecordsByEmployeeId(int employeeId,
        CancellationToken cancellationToken = default)
    {
        return await dbContext.LeaveRecords.Where(leaveRecord => leaveRecord.EmployeeId == employeeId)
            .ToListAsync(cancellationToken);
    }
}