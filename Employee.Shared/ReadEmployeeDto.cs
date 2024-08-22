namespace Employee.Shared;

public record ReadEmployeeDto(
    int EmployeeId,
    string? Name,
    string? Surname,
    string? Email,
    DateTime BirthDate,
    int DepartmentId,
    ReadDepartmentDto? Department,
    int JobTitleId,
    ReadJobTitleDto? JobTitle,
    DateTime HireDate);