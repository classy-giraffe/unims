using Employee.Repository.Models;

namespace Employee.Repository.Abstraction;

public interface IRepository
{
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    public Task CreateEmployee(
        Models.Employee employee,
        CancellationToken cancellationToken = default
    );

    public Task<Models.Employee?> GetEmployeeById(int employeeId, CancellationToken cancellationToken = default);

    public Task<IEnumerable<Models.Employee>> GetEmployees(CancellationToken cancellationToken = default);

    public Task<bool> DeleteEmployee(int employeeId, CancellationToken cancellationToken = default);

    public Task<IEnumerable<Models.Employee>> GetEmployeesByDepartment(int departmentId,
        CancellationToken cancellationToken = default);

    public Task<IEnumerable<Models.Employee>> GetEmployeesByJobTitle(int jobTitleId,
        CancellationToken cancellationToken = default);

    public Task<IEnumerable<Models.Employee>> GetEmployeesByHireDate(DateTime hireDate,
        CancellationToken cancellationToken = default);

    public Task CreateDepartment(Department department, CancellationToken cancellationToken = default);

    public Task<Department?> GetDepartmentById(int departmentId, CancellationToken cancellationToken = default);

    public Task<IEnumerable<Department>> GetDepartments(CancellationToken cancellationToken = default);


    public Task<bool> DeleteDepartment(int departmentId, CancellationToken cancellationToken = default);

    public Task CreateJobTitle(JobTitle jobTitle, CancellationToken cancellationToken = default);

    public Task<JobTitle?> GetJobTitleById(int jobTitleId, CancellationToken cancellationToken = default);

    public Task<IEnumerable<JobTitle>> GetJobTitles(CancellationToken cancellationToken = default);

    public Task<bool> DeleteJobTitle(int jobTitleId, CancellationToken cancellationToken = default);
}