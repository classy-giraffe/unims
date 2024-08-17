namespace Attendance.Shared;

public record UpdateAttendanceDto(int AttendanceId, DateTime Date, TimeSpan TimeIn, TimeSpan TimeOut, int EmployeeId);