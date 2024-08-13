using Employee.Business.Abstraction;
using Employee.Repository.Abstraction;
using Employee.Shared;
using Microsoft.Extensions.Logging;

namespace Employee.Business;

public class Business(IRepository repository, ILogger<Business> logger) : IBusiness
{
    public async Task CreateJobTitle(CreateJobTitleDto createJobTitleDto, CancellationToken cancellationToken)
    {
        await repository.CreateJobTitle(createJobTitleDto.Name, createJobTitleDto.Description, cancellationToken);
        await repository.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteJobTitle(int jobTitleId, CancellationToken cancellationToken)
    {
        var jobTitle = await repository.GetJobTitleById(jobTitleId, cancellationToken);
        if (jobTitle is null)
        {
            logger.LogError("Job title with id {jobTitleId} not found", jobTitleId);
            return;
        }

        await repository.DeleteJobTitle(jobTitleId, cancellationToken);
        await repository.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteDepartment(int departmentId, CancellationToken cancellationToken)
    {
        var department = await repository.GetDepartmentById(departmentId, cancellationToken);
        if (department is null)
        {
            logger.LogError("Department with id {departmentId} not found", departmentId);
            return;
        }

        await repository.DeleteDepartment(departmentId, cancellationToken);
        await repository.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateJobTitle(UpdateJobTitleDto updateJobTitleDto, CancellationToken cancellationToken)
    {
        var jobTitle = await repository.GetJobTitleById(updateJobTitleDto.JobTitleId, cancellationToken);
        if (jobTitle is null)
        {
            logger.LogError("Job title with id {jobTitleId} not found", updateJobTitleDto.JobTitleId);
            return;
        }

        jobTitle.Name = updateJobTitleDto.Name;
        jobTitle.Description = updateJobTitleDto.Description;
        await repository.SaveChangesAsync(cancellationToken);
    }

    public async Task<IEnumerable<ReadJobTitleDto>> GetJobTitles(CancellationToken cancellationToken)
    {
        var jobTitles = await repository.GetJobTitles(cancellationToken);
        return jobTitles.Select(jobTitle => new ReadJobTitleDto
        {
            JobTitleId = jobTitle.JobTitleId,
            Title = jobTitle.Name,
            Description = jobTitle.Description
        });
    }

    public async Task<ReadJobTitleDto?> GetJobTitleById(int jobTitleId, CancellationToken cancellationToken)
    {
        var jobTitle = await repository.GetJobTitleById(jobTitleId, cancellationToken);
        return jobTitle is null
            ? null
            : new ReadJobTitleDto
            {
                JobTitleId = jobTitle.JobTitleId,
                Title = jobTitle.Name,
                Description = jobTitle.Description
            };
    }

    public async Task CreateEmployee(CreateEmployeeDto createEmployeeDto, CancellationToken cancellationToken)
    {
        await repository.CreateEmployee(
            createEmployeeDto.Name,
            createEmployeeDto.Surname,
            createEmployeeDto.Email,
            createEmployeeDto.BirthDate,
            createEmployeeDto.Department?.Name,
            createEmployeeDto.Department?.Description,
            createEmployeeDto.JobTitle?.Name,
            createEmployeeDto.JobTitle?.Description,
            createEmployeeDto.HireDate,
            cancellationToken
        );
        await repository.SaveChangesAsync(cancellationToken);
    }

    public async Task<ReadEmployeeDto?> GetEmployeeById(int employeeId, CancellationToken cancellationToken)
    {
        var employee = await repository.GetEmployeeById(employeeId, cancellationToken);
        return employee is null
            ? null
            : new ReadEmployeeDto
            {
                EmployeeId = employee.EmployeeId,
                Name = employee.Name,
                Surname = employee.Surname,
                Email = employee.Email,
                BirthDate = employee.BirthDate,
                DepartmentId = employee.DepartmentId,
                Department = employee.Department,
                JobTitleId = employee.JobTitleId,
                JobTitle = employee.JobTitle,
                HireDate = employee.HireDate
            };
    }

    public async Task<IEnumerable<ReadEmployeeDto>> GetEmployees(CancellationToken cancellationToken)
    {
        var employees = await repository.GetEmployees(cancellationToken);
        return employees.Select(employee => new ReadEmployeeDto
        {
            EmployeeId = employee.EmployeeId,
            Name = employee.Name,
            Surname = employee.Surname,
            Email = employee.Email,
            BirthDate = employee.BirthDate,
            DepartmentId = employee.DepartmentId,
            Department = employee.Department,
            JobTitleId = employee.JobTitleId,
            JobTitle = employee.JobTitle,
            HireDate = employee.HireDate
        });
    }

    public async Task UpdateEmployee(UpdateEmployeeDto updateEmployeeDto, CancellationToken cancellationToken)
    {
        var employee = await repository.GetEmployeeById(updateEmployeeDto.EmployeeId, cancellationToken);
        if (employee is null) throw new Exception($"Employee with id {updateEmployeeDto.EmployeeId} not found");
        await repository.UpdateEmployee(
            updateEmployeeDto.EmployeeId,
            updateEmployeeDto.Name,
            updateEmployeeDto.Surname,
            updateEmployeeDto.Email,
            updateEmployeeDto.BirthDate,
            updateEmployeeDto.Department?.Name,
            updateEmployeeDto.Department?.Description,
            updateEmployeeDto.JobTitle?.Name,
            updateEmployeeDto.JobTitle?.Description,
            updateEmployeeDto.HireDate,
            cancellationToken
        );
        await repository.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteEmployee(int employeeId, CancellationToken cancellationToken)
    {
        var employee = await repository.GetEmployeeById(employeeId, cancellationToken);
        if (employee is null) throw new Exception($"Employee with id {employeeId} not found");

        await repository.DeleteEmployee(employeeId, cancellationToken);
        await repository.SaveChangesAsync(cancellationToken);
    }

    public async Task<IEnumerable<ReadEmployeeDto>> GetEmployeesByDepartment(int departmentId,
        CancellationToken cancellationToken)
    {
        var employees = await repository.GetEmployeesByDepartment(departmentId, cancellationToken);
        return employees.Select(employee => new ReadEmployeeDto
        {
            EmployeeId = employee.EmployeeId,
            Name = employee.Name,
            Surname = employee.Surname,
            Email = employee.Email,
            BirthDate = employee.BirthDate,
            DepartmentId = employee.DepartmentId,
            Department = employee.Department,
            JobTitleId = employee.JobTitleId,
            JobTitle = employee.JobTitle,
            HireDate = employee.HireDate
        });
    }

    public async Task<IEnumerable<ReadEmployeeDto>> GetEmployeesByJobTitle(int jobTitleId,
        CancellationToken cancellationToken)
    {
        var employees = await repository.GetEmployeesByJobTitle(jobTitleId, cancellationToken);
        return employees.Select(employee => new ReadEmployeeDto
        {
            EmployeeId = employee.EmployeeId,
            Name = employee.Name,
            Surname = employee.Surname,
            Email = employee.Email,
            BirthDate = employee.BirthDate,
            DepartmentId = employee.DepartmentId,
            Department = employee.Department,
            JobTitleId = employee.JobTitleId,
            JobTitle = employee.JobTitle,
            HireDate = employee.HireDate
        });
    }

    public async Task<IEnumerable<ReadEmployeeDto>> GetEmployeesByHireDate(DateTime hireDate,
        CancellationToken cancellationToken)
    {
        var employees = await repository.GetEmployeesByHireDate(hireDate, cancellationToken);
        return employees.Select(employee => new ReadEmployeeDto
        {
            EmployeeId = employee.EmployeeId,
            Name = employee.Name,
            Surname = employee.Surname,
            Email = employee.Email,
            BirthDate = employee.BirthDate,
            DepartmentId = employee.DepartmentId,
            Department = employee.Department,
            JobTitleId = employee.JobTitleId,
            JobTitle = employee.JobTitle,
            HireDate = employee.HireDate
        });
    }

    public async Task CreateDepartment(CreateDepartmentDto createDepartmentDto, CancellationToken cancellationToken)
    {
        await repository.CreateDepartment(createDepartmentDto.Name, createDepartmentDto.Description, cancellationToken);
        await repository.SaveChangesAsync(cancellationToken);
    }

    public async Task<ReadDepartmentDto?> GetDepartmentById(int departmentId, CancellationToken cancellationToken)
    {
        var department = await repository.GetDepartmentById(departmentId, cancellationToken);
        return department is null
            ? null
            : new ReadDepartmentDto
            {
                DepartmentId = department.DepartmentId,
                Name = department.Name,
                Description = department.Description
            };
    }

    public async Task<IEnumerable<ReadDepartmentDto>> GetDepartments(CancellationToken cancellationToken)
    {
        var departments = await repository.GetDepartments(cancellationToken);
        return departments.Select(department => new ReadDepartmentDto
        {
            DepartmentId = department.DepartmentId,
            Name = department.Name,
            Description = department.Description
        });
    }

    public async Task UpdateDepartment(UpdateDepartmentDto updateDepartmentDto, CancellationToken cancellationToken)
    {
        var department = await repository.GetDepartmentById(updateDepartmentDto.DepartmentId, cancellationToken);
        if (department is null) throw new Exception($"Department with id {updateDepartmentDto.DepartmentId} not found");

        department.Name = updateDepartmentDto.Name;
        department.Description = updateDepartmentDto.Description;
    }
}