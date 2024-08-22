using Microsoft.EntityFrameworkCore;
using Payroll.Repository.Abstractions;
using Payroll.Repository.Models;

namespace Payroll.Repository;

public class Repository(PayrollDbContext dbContext) : IRepository
{
    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task CreatePayroll(Models.Payroll payroll, CancellationToken cancellationToken = default)
    {
        await dbContext.Payrolls.AddAsync(payroll, cancellationToken);
    }

    public async Task<Models.Payroll?> GetPayrollById(int payrollId, CancellationToken cancellationToken = default)
    {
        return await dbContext.Payrolls
            .Include(p => p.Deductions)
            .FirstOrDefaultAsync(p => p.PayrollId == payrollId, cancellationToken);
    }

    public async Task<IEnumerable<Models.Payroll>> GetPayrollsByEmployeeId(int employeeId,
        CancellationToken cancellationToken = default)
    {
        return await dbContext.Payrolls
            .Include(p => p.Deductions)
            .Where(p => p.EmployeeId == employeeId)
            .ToListAsync(cancellationToken);
    }

    public async Task CreateSalary(Salary salary, CancellationToken cancellationToken = default)
    {
        await dbContext.Salaries.AddAsync(salary, cancellationToken);
    }

    public async Task<Salary?> GetSalaryById(int salaryId, CancellationToken cancellationToken = default)
    {
        return await dbContext.Salaries
            .FirstOrDefaultAsync(s => s.SalaryId == salaryId, cancellationToken);
    }

    public async Task<IEnumerable<Salary>> GetSalariesByEmployeeId(int employeeId,
        CancellationToken cancellationToken = default)
    {
        return await dbContext.Salaries
            .Where(s => s.EmployeeId == employeeId)
            .ToListAsync(cancellationToken);
    }

    public async Task CreateDeduction(Deduction deduction, CancellationToken cancellationToken = default)
    {
        await dbContext.Deductions.AddAsync(deduction, cancellationToken);
    }

    public async Task<Deduction?> GetDeductionById(int deductionId, CancellationToken cancellationToken = default)
    {
        return await dbContext.Deductions
            .FirstOrDefaultAsync(d => d.DeductionId == deductionId, cancellationToken);
    }

    public async Task<IEnumerable<Deduction>> GetDeductionsByPayrollId(int payrollId,
        CancellationToken cancellationToken = default)
    {
        return await dbContext.Deductions
            .Where(d => d.PayrollId == payrollId)
            .ToListAsync(cancellationToken);
    }
}