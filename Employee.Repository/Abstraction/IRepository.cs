using Employee.Repository.Models;

namespace Employee.Repository.Abstraction;

public interface IRepository
{
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    public Task CreateEmployee(
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
    );

    public Task<Models.Employee?> GetEmployeeById(int employeeId, CancellationToken cancellationToken = default);

    public Task<IEnumerable<Models.Employee>> GetEmployees(CancellationToken cancellationToken = default);

    public Task UpdateEmployee(
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
    );

    public Task DeleteEmployee(int employeeId, CancellationToken cancellationToken = default);
    
    public Task<IEnumerable<Models.Employee>> GetEmployeesByDepartment(int departmentId,
        CancellationToken cancellationToken = default);

    public Task<IEnumerable<Models.Employee>> GetEmployeesByJobTitle(int jobTitleId,
        CancellationToken cancellationToken = default);
    
    public Task<IEnumerable<Models.Employee>> GetEmployeesByHireDate(DateTime hireDate,
        CancellationToken cancellationToken = default);
    
    public Task CreateDepartment(
        string? name,
        string? description,
        CancellationToken cancellationToken = default
    );
    
    public Task<Department?> GetDepartmentById(int departmentId, CancellationToken cancellationToken = default);

    public Task<IEnumerable<Department>> GetDepartments(CancellationToken cancellationToken = default);

    public Task UpdateDepartment(
        int departmentId,
        string name,
        string description,
        CancellationToken cancellationToken = default
    );

    public Task DeleteDepartment(int departmentId, CancellationToken cancellationToken = default);

    public Task CreateJobTitle(
        string? name,
        string? description,
        CancellationToken cancellationToken = default
    );

    public Task<JobTitle?> GetJobTitleById(int jobTitleId, CancellationToken cancellationToken = default);

    public Task<IEnumerable<JobTitle>> GetJobTitles(CancellationToken cancellationToken = default);

    public Task UpdateJobTitle(
        int jobTitleId,
        string name,
        string description,
        CancellationToken cancellationToken = default
    );

    public Task DeleteJobTitle(int jobTitleId, CancellationToken cancellationToken = default);
    
}