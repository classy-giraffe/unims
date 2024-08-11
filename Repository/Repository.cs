using Microsoft.EntityFrameworkCore;
using Repository.Abstraction;
using Repository.Models;

namespace Repository;

public class Repository(EmployeeDbContext dbContext) : IRepository
{
    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task CreateEmployee(
        string name,
        string surname,
        string email,
        DateTime birthDate,
        Department department,
        JobTitle jobTitle,
        DateTime hireDate,
        CancellationToken cancellationToken = default
    )
    {
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
}