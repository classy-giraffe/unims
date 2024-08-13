namespace Employee.Repository;
using Abstraction;
using Models;
using Microsoft.EntityFrameworkCore;

public class Repository(EmployeeDbContext dbContext) : IRepository
{
    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task CreateEmployee(
        string? name,
        string? surname,
        string? email,
        DateTime birthDate,
        string? departmentName,
        string? departmentDescription,
        string? jobTitleName,
        string? jobTitleDescription,
        DateTime hireDate,
        CancellationToken cancellationToken = default
    )
    {
        var department = await dbContext.Departments
            .Where(d => d.Name == departmentName)
            .FirstOrDefaultAsync(cancellationToken);

        if (department is null)
        {
            department = new Department
            {
                Name = departmentName,
                Description = departmentDescription
            };

            await dbContext.Departments.AddAsync(department, cancellationToken);
        }

        var jobTitle = await dbContext.JobTitles
            .Where(jt => jt.Name == jobTitleName)
            .FirstOrDefaultAsync(cancellationToken);

        if (jobTitle is null)
        {
            jobTitle = new JobTitle
            {
                Name = jobTitleName,
                Description = jobTitleDescription
            };

            await dbContext.JobTitles.AddAsync(jobTitle, cancellationToken);
        }

        var employee = new Employee
        {
            Name = name,
            Surname = surname,
            Email = email,
            BirthDate = birthDate,
            Department = department,
            JobTitle = jobTitle,
            HireDate = hireDate
        };

        await dbContext.Employees.AddAsync(employee, cancellationToken);
    }

    public async Task<Employee?> GetEmployeeById(int employeeId, CancellationToken cancellationToken = default)
    {
        return await dbContext.Employees
            .Where(e => e.EmployeeId == employeeId)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<IEnumerable<Employee>> GetEmployees(CancellationToken cancellationToken = default)
    {
        return await dbContext.Employees.ToListAsync(cancellationToken);
    }
    
    public async Task UpdateEmployee(
        int employeeId,
        string? name,
        string? surname,
        string? email,
        DateTime birthDate,
        string? departmentName,
        string? departmentDescription,
        string? jobTitleName,
        string? jobTitleDescription,
        DateTime hireDate,
        CancellationToken cancellationToken = default
    )
    {
        var employee = await dbContext.Employees
            .Where(e => e.EmployeeId == employeeId)
            .FirstOrDefaultAsync(cancellationToken);

        if (employee is null) return;

        var department = await dbContext.Departments
            .Where(d => d.Name == departmentName)
            .FirstOrDefaultAsync(cancellationToken);

        if (department is null)
        {
            department = new Department
            {
                Name = departmentName,
                Description = departmentDescription
            };

            await dbContext.Departments.AddAsync(department, cancellationToken);
        }

        var jobTitle = await dbContext.JobTitles
            .Where(jt => jt.Name == jobTitleName)
            .FirstOrDefaultAsync(cancellationToken);

        if (jobTitle is null)
        {
            jobTitle = new JobTitle
            {
                Name = jobTitleName,
                Description = jobTitleDescription
            };

            await dbContext.JobTitles.AddAsync(jobTitle, cancellationToken);
        }

        employee.Name = name;
        employee.Surname = surname;
        employee.Email = email;
        employee.BirthDate = birthDate;
        employee.Department = department;
        employee.JobTitle = jobTitle;
        employee.HireDate = hireDate;

        dbContext.Employees.Update(employee);
    }

    public async Task UpdateJobTitle(int jobTitleId,
        string name,
        string description,
        CancellationToken cancellationToken = default)
    {
        var jobTitle = await dbContext.JobTitles
            .Where(jt => jt.JobTitleId == jobTitleId)
            .FirstOrDefaultAsync(cancellationToken);

        if (jobTitle is null) return;

        jobTitle.Name = name;
        jobTitle.Description = description;
        dbContext.JobTitles.Update(jobTitle);
    }

    public async Task DeleteEmployee(int employeeId, CancellationToken cancellationToken = default)
    {
        var employee = await dbContext.Employees
            .Where(e => e.EmployeeId == employeeId)
            .FirstOrDefaultAsync(cancellationToken);

        if (employee is null) return;

        dbContext.Employees.Remove(employee);
    }
    
    public async Task<IEnumerable<Employee>> GetEmployeesByDepartment(int departmentId,
        CancellationToken cancellationToken = default)
    {
        return await dbContext.Employees
            .Where(e => e.Department.DepartmentId == departmentId)
            .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<Employee>> GetEmployeesByJobTitle(int jobTitleId,
        CancellationToken cancellationToken = default)
    {
        return await dbContext.Employees
            .Where(e => e.JobTitle.JobTitleId == jobTitleId)
            .ToListAsync(cancellationToken);
    }
    
    public async Task<IEnumerable<Employee>> GetEmployeesByHireDate(DateTime hireDate,
        CancellationToken cancellationToken = default)
    {
        return await dbContext.Employees
            .Where(e => e.HireDate == hireDate)
            .ToListAsync(cancellationToken);
    }
    
    public async Task CreateDepartment(
        string? name,
        string? description,
        CancellationToken cancellationToken = default
    )
    {
        var department = new Department
        {
            Name = name,
            Description = description
        };

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

    public async Task UpdateDepartment(
        int departmentId,
        string name,
        string description,
        CancellationToken cancellationToken = default
    )
    {
        var department = await dbContext.Departments
            .Where(d => d.DepartmentId == departmentId)
            .FirstOrDefaultAsync(cancellationToken);

        if (department is null) return;

        department.Name = name;
        department.Description = description;
        dbContext.Departments.Update(department);
    }

    public async Task DeleteDepartment(int departmentId, CancellationToken cancellationToken = default)
    {
        var department = await dbContext.Departments
            .Where(d => d.DepartmentId == departmentId)
            .FirstOrDefaultAsync(cancellationToken);

        if (department is null) return;

        dbContext.Departments.Remove(department);
    }

    public async Task CreateJobTitle(
        string? name,
        string? description,
        CancellationToken cancellationToken = default
    )
    {
        var jobTitle = new JobTitle
        {
            Name = name,
            Description = description
        };

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

    public async Task DeleteJobTitle(int jobTitleId, CancellationToken cancellationToken = default)
    {
        var jobTitle = await dbContext.JobTitles
            .Where(jt => jt.JobTitleId == jobTitleId)
            .FirstOrDefaultAsync(cancellationToken);

        if (jobTitle is null) return;

        dbContext.JobTitles.Remove(jobTitle);
    }
}