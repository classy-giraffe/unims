using Employee.Shared;

namespace Employee.Business.Abstraction;

public interface IBusiness
{
    public Task CreateEmployee(CreateEmployeeDto createEmployeeDto, CancellationToken cancellationToken);
    public Task<ReadEmployeeDto?> GetEmployeeById(int employeeId, CancellationToken cancellationToken);
    public Task<IEnumerable<ReadEmployeeDto>> GetEmployees(CancellationToken cancellationToken);
    public Task UpdateEmployee(UpdateEmployeeDto updateEmployeeDto, CancellationToken cancellationToken);
    public Task<bool> DeleteEmployee(int employeeId, CancellationToken cancellationToken);

    public Task<IEnumerable<ReadEmployeeDto>> GetEmployeesByDepartment(int departmentId,
        CancellationToken cancellationToken);

    public Task<IEnumerable<ReadEmployeeDto>> GetEmployeesByJobTitle(int jobTitleId,
        CancellationToken cancellationToken);

    public Task<IEnumerable<ReadEmployeeDto>> GetEmployeesByHireDate(DateTime hireDate,
        CancellationToken cancellationToken);

    public Task CreateDepartment(CreateDepartmentDto createDepartmentDto, CancellationToken cancellationToken);
    public Task<ReadDepartmentDto?> GetDepartmentById(int departmentId, CancellationToken cancellationToken);
    public Task<IEnumerable<ReadDepartmentDto>> GetDepartments(CancellationToken cancellationToken);
    public Task UpdateDepartment(UpdateDepartmentDto updateDepartmentDto, CancellationToken cancellationToken);
    public Task<bool> DeleteDepartment(int departmentId, CancellationToken cancellationToken);

    public Task CreateJobTitle(CreateJobTitleDto createJobTitleDto, CancellationToken cancellationToken);
    public Task<ReadJobTitleDto?> GetJobTitleById(int jobTitleId, CancellationToken cancellationToken);
    public Task<IEnumerable<ReadJobTitleDto>> GetJobTitles(CancellationToken cancellationToken);
    public Task UpdateJobTitle(UpdateJobTitleDto updateJobTitleDto, CancellationToken cancellationToken);
    public Task<bool> DeleteJobTitle(int jobTitleId, CancellationToken cancellationToken);
}