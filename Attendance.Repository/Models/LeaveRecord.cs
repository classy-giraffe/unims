namespace Attendance.Repository.Models;

public class LeaveRecord
{
    public int LeaveRecordId { get; set; }
    public int EmployeeId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string? LeaveType { get; set; }
    public string? Reason { get; set; }
    public bool IsApproved { get; set; }
}