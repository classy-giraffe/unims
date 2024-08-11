using Repository.Models;

namespace Repository.Abstraction;

public interface IRepository
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    Task CreateEmployee(
        string name,
        string surname,
        string email,
        DateTime birthDate,
        Department department,
        JobTitle jobTitle,
        DateTime hireDate,
        CancellationToken cancellationToken = default
    );
    
    Task<Employee?> GetEmployeeById(int employeeId, CancellationToken cancellationToken = default);
}