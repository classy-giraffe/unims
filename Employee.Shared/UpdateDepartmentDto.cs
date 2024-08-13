namespace Employee.Shared;

public class UpdateDepartmentDto
{
    public int DepartmentId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
}