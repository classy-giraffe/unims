using Attendance.Shared;

namespace Attendance.Business.Abstractions;

public interface IBusiness
{
    public Task<bool> CreateAttendance(CreateAttendanceDto createAttendanceDto,
        CancellationToken cancellationToken = default);

    public Task<ReadAttendanceDto?> GetAttendanceById(int attendanceId, CancellationToken cancellationToken = default);

    public Task<IEnumerable<ReadAttendanceDto>> GetAttendancesByEmployeeId(int employeeId,
        CancellationToken cancellationToken = default);

    public Task<bool> UpdateAttendance(UpdateAttendanceDto updateAttendanceDto,
        CancellationToken cancellationToken = default);

    public Task<bool> DeleteAttendance(int attendanceId, CancellationToken cancellationToken = default);
    public Task<IEnumerable<ReadAttendanceDto>> GetAttendances(CancellationToken cancellationToken = default);

    public Task<bool> CreateLeaveRecord(CreateLeaveRecordDto createLeaveRecordDto,
        CancellationToken cancellationToken = default);

    public Task<ReadLeaveRecordDto?> GetLeaveRecordById(int leaveRecordId,
        CancellationToken cancellationToken = default);

    public Task<IEnumerable<ReadLeaveRecordDto>> GetLeaveRecordsByEmployeeId(int employeeId,
        CancellationToken cancellationToken = default);

    public Task<bool> UpdateLeaveRecord(UpdateLeaveRecordDto updateLeaveRecordDto,
        CancellationToken cancellationToken = default);

    public Task<bool> DeleteLeaveRecord(int leaveRecordId,
        CancellationToken cancellationToken = default);

    public Task<bool> ValidateEmployee(int employeeId, CancellationToken cancellationToken = default);
    public Task<IEnumerable<ReadLeaveRecordDto>> GetLeaveRecords(CancellationToken cancellationToken = default);
}