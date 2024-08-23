namespace Payroll.Shared;

public record CreatePayrollDto(
    int EmployeeId,
    decimal GrossSalary,
    decimal NetSalary,
    DateTime PayrollDate,
    List<CreateDeductionDto> Deductions
);

public record ReadPayrollDto(
    int PayrollId,
    int EmployeeId,
    decimal GrossSalary,
    decimal NetSalary,
    DateTime PayrollDate,
    List<ReadDeductionDto> Deductions
);

public record UpdatePayrollDto(
    int PayrollId,
    decimal GrossSalary,
    decimal NetSalary,
    DateTime PayrollDate,
    List<UpdateDeductionDto> Deductions
);