namespace Employee.Shared;

public record CreateDepartmentDto
{
    public string? Name { get; set; }
    public string? Description { get; set; }
}