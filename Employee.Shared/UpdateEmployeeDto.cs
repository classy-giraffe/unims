namespace Employee.Shared;

public record UpdateEmployeeDto(
    int EmployeeId,
    string? Name,
    string? Surname,
    string? Email,
    DateTime BirthDate,
    UpdateDepartmentDto? Department,
    UpdateJobTitleDto? JobTitle,
    DateTime HireDate);