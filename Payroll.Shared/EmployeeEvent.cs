namespace Payroll.Shared;

public enum Event
{
    Created,
    Deleted
}

public class EmployeeEvent
{
    public int Id { get; set; }
    public Event Event { get; set; }
}