using Employee.Repository.Models;

namespace Employee.Shared;

public class UpdateEmployeeDto
{
    public int EmployeeId { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? Email { get; set; }
    public DateTime BirthDate { get; set; }
    public UpdateDepartmentDto? Department { get; set; }
    public UpdateJobTitleDto? JobTitle { get; set; }
    public DateTime HireDate { get; set; }
}