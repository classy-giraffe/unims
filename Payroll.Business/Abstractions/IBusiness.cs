using Payroll.Shared;

namespace Payroll.Business.Abstractions;

public interface IBusiness
{
    Task<bool> CreatePayroll(CreatePayrollDto createPayrollDto, CancellationToken cancellationToken = default);
    Task<ReadPayrollDto?> GetPayrollById(int payrollId, CancellationToken cancellationToken = default);
    Task<bool> UpdatePayroll(UpdatePayrollDto updatePayrollDto, CancellationToken cancellationToken = default);
    Task<bool> DeletePayroll(int payrollId, CancellationToken cancellationToken = default);

    Task<IEnumerable<ReadPayrollDto>> GetPayrollsByEmployeeId(int employeeId,
        CancellationToken cancellationToken = default);

    Task<IEnumerable<ReadPayrollDto>> GetPayrolls(CancellationToken cancellationToken = default);

    Task CreateSalary(CreateSalaryDto createSalaryDto, CancellationToken cancellationToken = default);
    Task<ReadSalaryDto?> GetSalaryById(int salaryId, CancellationToken cancellationToken = default);
    Task<bool> UpdateSalary(UpdateSalaryDto updateSalaryDto, CancellationToken cancellationToken = default);
    Task<bool> DeleteSalary(int salaryId, CancellationToken cancellationToken = default);
    Task<IEnumerable<ReadSalaryDto>> GetSalaries(CancellationToken cancellationToken = default);

    Task<IEnumerable<ReadSalaryDto>> GetSalariesByEmployeeId(int employeeId,
        CancellationToken cancellationToken = default);

    Task CreateDeduction(CreateDeductionDto createDeductionDto, CancellationToken cancellationToken = default);
    Task<ReadDeductionDto?> GetDeductionById(int deductionId, CancellationToken cancellationToken = default);
    Task<bool> UpdateDeduction(UpdateDeductionDto updateDeductionDto, CancellationToken cancellationToken = default);
    Task<bool> DeleteDeduction(int deductionId, CancellationToken cancellationToken = default);
    Task<IEnumerable<ReadDeductionDto>> GetDeductions(CancellationToken cancellationToken = default);

    Task<IEnumerable<ReadDeductionDto>> GetDeductionsByPayrollId(int payrollId,
        CancellationToken cancellationToken = default);
}