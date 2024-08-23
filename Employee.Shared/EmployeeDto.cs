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

public class ReadEmployeeDto
{
    public int EmployeeId { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? Email { get; set; }
    public DateTime BirthDate { get; set; }
    public int DepartmentId { get; set; }
    public ReadDepartmentDto? Department { get; set; }
    public int JobTitleId { get; set; }
    public ReadJobTitleDto? JobTitle { get; set; }
    public DateTime HireDate { get; set; }
}

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