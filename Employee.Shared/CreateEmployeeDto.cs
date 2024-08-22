namespace Employee.Shared;

public record CreateEmployeeDto(
    string Name,
    string Surname,
    string Email,
    DateTime BirthDate,
    CreateJobTitleDto JobTitle,
    CreateDepartmentDto Department,
    DateTime HireDate);