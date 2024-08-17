namespace Attendance.Shared;

public record ReadAttendanceDto(
    int AttendanceId,
    int EmployeeId,
    DateTime Date,
    DateTime CheckInTime,
    DateTime CheckOutTime,
    TimeSpan TotalHoursWorked);