namespace Attendance.Shared;

public record ReadLeaveRecordDto(
    int LeaveRecordId,
    int EmployeeId,
    DateTime StartDate,
    DateTime EndDate,
    string? LeaveType,
    string? Reason,
    bool IsApproved);