using Payroll.Repository.Models;

namespace Payroll.Repository.Abstractions;

public interface IRepository
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    Task CreatePayroll(Models.Payroll payroll, CancellationToken cancellationToken = default);
    Task<Models.Payroll?> GetPayrollById(int payrollId, CancellationToken cancellationToken = default);

    Task<IEnumerable<Models.Payroll>> GetPayrollsByEmployeeId(int employeeId,
        CancellationToken cancellationToken = default);

    Task CreateSalary(Salary salary, CancellationToken cancellationToken = default);
    Task<Salary?> GetSalaryById(int salaryId, CancellationToken cancellationToken = default);
    Task<IEnumerable<Salary>> GetSalariesByEmployeeId(int employeeId, CancellationToken cancellationToken = default);

    Task CreateDeduction(Deduction deduction, CancellationToken cancellationToken = default);
    Task<Deduction?> GetDeductionById(int deductionId, CancellationToken cancellationToken = default);
    Task<IEnumerable<Deduction>> GetDeductionsByPayrollId(int payrollId, CancellationToken cancellationToken = default);
}