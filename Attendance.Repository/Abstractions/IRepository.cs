using Attendance.Repository.Models;

namespace Attendance.Repository.Abstractions;

public interface IRepository
{
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    public Task CreateAttendance(
        Models.Attendance attendance,
        CancellationToken cancellationToken = default
    );

    public Task<Models.Attendance?> GetAttendanceById(int attendanceId, CancellationToken cancellationToken = default);

    public Task<IEnumerable<Models.Attendance>> GetAttendances(CancellationToken cancellationToken = default);

    public Task<bool> DeleteAttendance(int attendanceId, CancellationToken cancellationToken = default);

    public Task CreateLeaveRecord(
        LeaveRecord leaveRecord,
        CancellationToken cancellationToken = default
    );

    public Task<LeaveRecord?> GetLeaveRecordById(int leaveRecordId, CancellationToken cancellationToken = default);

    public Task<IEnumerable<LeaveRecord>> GetLeaveRecords(CancellationToken cancellationToken = default);

    public Task<bool> DeleteLeaveRecord(int leaveRecordId, CancellationToken cancellationToken = default);
    
    public Task<IEnumerable<Models.Attendance>> GetAttendancesByEmployeeId(int employeeId, CancellationToken cancellationToken = default);
    
    public Task<IEnumerable<LeaveRecord>> GetLeaveRecordsByEmployeeId(int employeeId, CancellationToken cancellationToken = default);
}