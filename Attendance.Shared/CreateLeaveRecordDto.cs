namespace Attendance.Shared;

public record CreateLeaveRecordDto(
    int EmployeeId,
    DateTime StartDate,
    DateTime EndDate,
    string? LeaveType,
    string? Reason,
    bool IsApproved);