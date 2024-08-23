namespace Attendance.Shared;

public class AttendanceDto
{
    public int EmployeeId { get; set; }
    public DateTime Date { get; set; }
    public DateTime CheckInTime { get; set; }
    public DateTime CheckOutTime { get; set; }
}

public class ReadAttendanceDto
{
    public int AttendanceId { get; set; }
    public int EmployeeId { get; set; }
    public DateTime Date { get; set; }
    public DateTime CheckInTime { get; set; }
    public DateTime CheckOutTime { get; set; }
    public TimeSpan TotalHoursWorked { get; set; }
}

public class UpdateAttendanceDto
{
    public int AttendanceId { get; set; }
    public DateTime Date { get; set; }
    public DateTime CheckInTime { get; set; }
    public DateTime CheckOutTime { get; set; }
    public int EmployeeId { get; set; }
}