using Employee.Repository.Models;

namespace Employee.Shared;

public class CreateEmployeeDto
{
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? Email { get; set; }
    public DateTime BirthDate { get; set; }
    public CreateJobTitleDto? JobTitle { get; set; }
    public CreateDepartmentDto? Department { get; set; }
    public DateTime HireDate { get; set; }
}