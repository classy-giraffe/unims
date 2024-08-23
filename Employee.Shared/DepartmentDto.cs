namespace Employee.Shared;

public class CreateDepartmentDto
{
    public string? Name { get; set; }
    public string? Description { get; set; }
}

public class ReadDepartmentDto
{
    public int DepartmentId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
}

public class UpdateDepartmentDto
{
    public int DepartmentId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
}