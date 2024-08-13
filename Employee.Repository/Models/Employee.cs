namespace Employee.Repository.Models;

public class Employee
{
    public int EmployeeId { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? Email { get; set; }
    public DateTime BirthDate { get; set; }
    public int DepartmentId { get; set; }
    public Department? Department { get; set; }
    public int JobTitleId { get; set; }
    public JobTitle? JobTitle { get; set; }
    public DateTime HireDate { get; set; }
}