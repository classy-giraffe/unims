namespace Attendance.Shared;

public record CreateAttendanceDto(int EmployeeId, DateTime Date, DateTime CheckInTime, DateTime CheckOutTime);