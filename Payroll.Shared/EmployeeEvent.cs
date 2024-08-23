namespace Payroll.Shared;

public class EmployeeCreatedEvent
{
    public int EmployeeId { get; set; }
}

public class EmployeeDeletedEvent
{
    public int EmployeeId { get; set; }
}