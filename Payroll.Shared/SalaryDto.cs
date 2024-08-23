namespace Payroll.Shared;

public record CreateSalaryDto(
    int EmployeeId,
    decimal BaseSalary,
    DateTime EffectiveDate
);

public record ReadSalaryDto(
    int SalaryId,
    int EmployeeId,
    decimal BaseSalary,
    DateTime EffectiveDate
);

public record UpdateSalaryDto(
    int SalaryId,
    decimal BaseSalary,
    DateTime EffectiveDate
);