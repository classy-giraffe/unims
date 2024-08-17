namespace Attendance.Shared;

public record UpdateLeaveRecordDto(int LeaveRecordId, DateTime StartDate, DateTime EndDate, string LeaveType);