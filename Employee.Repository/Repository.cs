using Employee.Repository.Abstraction;
using Employee.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace Employee.Repository;

public class Repository(EmployeeDbContext dbContext) : IRepository
{
    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task CreateEmployee(Models.Employee employee, CancellationToken cancellationToken = default)
    {
        await dbContext.Employees.AddAsync(employee, cancellationToken);
    }

    public async Task<Models.Employee?> GetEmployeeById(int employeeId, CancellationToken cancellationToken = default)
    {
        return await dbContext.Employees
            .Where(e => e.EmployeeId == employeeId)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<IEnumerable<Models.Employee>> GetEmployees(CancellationToken cancellationToken = default)
    {
        return await dbContext.Employees.ToListAsync(cancellationToken);
    }

    public async Task<bool> DeleteEmployee(int employeeId, CancellationToken cancellationToken = default)
    {
        var employee = await GetEmployeeById(employeeId, cancellationToken);
        if (employee is null) return false;
        dbContext.Employees.Remove(employee);
        return true;
    }

    public async Task<IEnumerable<Models.Employee>> GetEmployeesByDepartment(int departmentId,
        CancellationToken cancellationToken = default)
    {
        return await dbContext.Employees
            .Where(e => e.Department.DepartmentId == departmentId)
            .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<Models.Employee>> GetEmployeesByJobTitle(int jobTitleId,
        CancellationToken cancellationToken = default)
    {
        return await dbContext.Employees
            .Where(e => e.JobTitle.JobTitleId == jobTitleId)
            .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<Models.Employee>> GetEmployeesByHireDate(DateTime hireDate,
        CancellationToken cancellationToken = default)
    {
        return await dbContext.Employees
            .Where(e => e.HireDate == hireDate)
            .ToListAsync(cancellationToken);
    }

    public async Task CreateDepartment(Department department, CancellationToken cancellationToken = default)
    {
        await dbContext.Departments.AddAsync(department, cancellationToken);
    }

    public async Task<Department?> GetDepartmentById(int departmentId, CancellationToken cancellationToken = default)
    {
        return await dbContext.Departments
            .Where(d => d.DepartmentId == departmentId)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<IEnumerable<Department>> GetDepartments(CancellationToken cancellationToken = default)
    {
        return await dbContext.Departments.ToListAsync(cancellationToken);
    }

    public async Task<bool> DeleteDepartment(int departmentId, CancellationToken cancellationToken = default)
    {
        var department = await GetDepartmentById(departmentId, cancellationToken);
        if (department is null) return false;
        dbContext.Departments.Remove(department);
        return true;
    }

    public async Task CreateJobTitle(JobTitle jobTitle, CancellationToken cancellationToken = default)
    {
        await dbContext.JobTitles.AddAsync(jobTitle, cancellationToken);
    }

    public async Task<JobTitle?> GetJobTitleById(int jobTitleId, CancellationToken cancellationToken = default)
    {
        return await dbContext.JobTitles
            .Where(jt => jt.JobTitleId == jobTitleId)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<IEnumerable<JobTitle>> GetJobTitles(CancellationToken cancellationToken = default)
    {
        return await dbContext.JobTitles.ToListAsync(cancellationToken);
    }

    public async Task<bool> DeleteJobTitle(int jobTitleId, CancellationToken cancellationToken = default)
    {
        var jobTitle = await GetJobTitleById(jobTitleId, cancellationToken);
        if (jobTitle is null) return false;
        dbContext.JobTitles.Remove(jobTitle);
        return true;
    }
}