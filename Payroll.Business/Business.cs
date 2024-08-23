using AutoMapper;
using Microsoft.Extensions.Logging;
using Payroll.Business.Abstractions;
using Payroll.Http.Abstractions;
using Payroll.Repository.Abstractions;
using Payroll.Repository.Models;
using Payroll.Shared;

namespace Payroll.Business;

public class Business(IRepository repository, IMapper mapper, ILogger<Business> logger, IClientHttp clientHttp)
    : IBusiness
{
    public async Task<bool> CreatePayroll(CreatePayrollDto createPayrollDto,
        CancellationToken cancellationToken = default)
    {
        var employeeExists = await clientHttp.ValidateEmployeeAsync(createPayrollDto.EmployeeId, cancellationToken);
        if (!employeeExists)
        {
            logger.LogError("Employee with id {employeeId} not found", createPayrollDto.EmployeeId);
            return false;
        }

        var payroll = mapper.Map<Repository.Models.Payroll>(createPayrollDto);
        await repository.CreatePayroll(payroll, cancellationToken);
        await repository.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<ReadPayrollDto?> GetPayrollById(int payrollId, CancellationToken cancellationToken = default)
    {
        var payroll = await repository.GetPayrollById(payrollId, cancellationToken);
        return payroll != null ? mapper.Map<ReadPayrollDto>(payroll) : null;
    }

    public async Task<bool> UpdatePayroll(UpdatePayrollDto updatePayrollDto,
        CancellationToken cancellationToken = default)
    {
        var payroll = await repository.GetPayrollById(updatePayrollDto.PayrollId, cancellationToken);
        if (payroll == null)
        {
            logger.LogError("Payroll with id {PayrollId} not found", updatePayrollDto.PayrollId);
            return false;
        }

        mapper.Map(updatePayrollDto, payroll);
        await repository.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<bool> DeletePayroll(int payrollId, CancellationToken cancellationToken = default)
    {
        var isDeleted = await repository.DeletePayroll(payrollId, cancellationToken);
        if (!isDeleted)
        {
            logger.LogError("Payroll with id {PayrollId} not found", payrollId);
            return false;
        }

        await repository.SaveChangesAsync(cancellationToken);
        return true;
    }

    // Salary methods
    public async Task CreateSalary(CreateSalaryDto createSalaryDto, CancellationToken cancellationToken = default)
    {
        var salary = mapper.Map<Salary>(createSalaryDto);
        await repository.CreateSalary(salary, cancellationToken);
        await repository.SaveChangesAsync(cancellationToken);
    }

    public async Task<ReadSalaryDto?> GetSalaryById(int salaryId, CancellationToken cancellationToken = default)
    {
        var salary = await repository.GetSalaryById(salaryId, cancellationToken);
        return salary != null ? mapper.Map<ReadSalaryDto>(salary) : null;
    }

    public async Task<bool> UpdateSalary(UpdateSalaryDto updateSalaryDto, CancellationToken cancellationToken = default)
    {
        var salary = await repository.GetSalaryById(updateSalaryDto.SalaryId, cancellationToken);
        if (salary == null)
        {
            logger.LogError("Salary with id {SalaryId} not found", updateSalaryDto.SalaryId);
            return false;
        }

        mapper.Map(updateSalaryDto, salary);
        await repository.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<bool> DeleteSalary(int salaryId, CancellationToken cancellationToken = default)
    {
        var isDeleted = await repository.DeleteSalary(salaryId, cancellationToken);
        if (!isDeleted)
        {
            logger.LogError("Salary with id {SalaryId} not found", salaryId);
            return false;
        }

        await repository.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<ReadDeductionDto?> GetDeductionById(int deductionId,
        CancellationToken cancellationToken = default)
    {
        var deduction = await repository.GetDeductionById(deductionId, cancellationToken);
        return deduction != null ? mapper.Map<ReadDeductionDto>(deduction) : null;
    }

    public async Task<bool> UpdateDeduction(UpdateDeductionDto updateDeductionDto,
        CancellationToken cancellationToken = default)
    {
        var deduction = await repository.GetDeductionById(updateDeductionDto.DeductionId, cancellationToken);
        if (deduction == null)
        {
            logger.LogError("Deduction with id {DeductionId} not found", updateDeductionDto.DeductionId);
            return false;
        }

        mapper.Map(updateDeductionDto, deduction);
        await repository.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<bool> DeleteDeduction(int deductionId, CancellationToken cancellationToken = default)
    {
        var isDeleted = await repository.DeleteDeduction(deductionId, cancellationToken);
        if (!isDeleted)
        {
            logger.LogError("Deduction with id {DeductionId} not found", deductionId);
            return false;
        }

        await repository.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<IEnumerable<ReadPayrollDto>> GetPayrolls(CancellationToken cancellationToken = default)
    {
        var payrolls = await repository.GetPayrolls(cancellationToken);
        return payrolls.Select(mapper.Map<ReadPayrollDto>);
    }

    public async Task<IEnumerable<ReadSalaryDto>> GetSalaries(CancellationToken cancellationToken = default)
    {
        var salaries = await repository.GetSalaries(cancellationToken);
        return salaries.Select(mapper.Map<ReadSalaryDto>);
    }

    public async Task<IEnumerable<ReadDeductionDto>> GetDeductions(CancellationToken cancellationToken = default)
    {
        var deductions = await repository.GetDeductions(cancellationToken);
        return deductions.Select(mapper.Map<ReadDeductionDto>);
    }

    public async Task CreateDeduction(CreateDeductionDto createDeductionDto,
        CancellationToken cancellationToken = default)
    {
        var deduction = mapper.Map<Deduction>(createDeductionDto);
        await repository.CreateDeduction(deduction, cancellationToken);
        await repository.SaveChangesAsync(cancellationToken);
    }

    public async Task<IEnumerable<ReadDeductionDto>> GetDeductionsByPayrollId(int payrollId,
        CancellationToken cancellationToken = default)
    {
        var deductions = await repository.GetDeductionsByPayrollId(payrollId, cancellationToken);
        return deductions.Select(mapper.Map<ReadDeductionDto>);
    }

    public async Task<IEnumerable<ReadSalaryDto>> GetSalariesByEmployeeId(int employeeId,
        CancellationToken cancellationToken = default)
    {
        var salaries = await repository.GetSalariesByEmployeeId(employeeId, cancellationToken);
        return salaries.Select(mapper.Map<ReadSalaryDto>);
    }

    public async Task<IEnumerable<ReadPayrollDto>> GetPayrollsByEmployeeId(int employeeId,
        CancellationToken cancellationToken = default)
    {
        var payrolls = await repository.GetPayrollsByEmployeeId(employeeId, cancellationToken);
        return payrolls.Select(mapper.Map<ReadPayrollDto>);
    }
}