namespace Payroll.Http.Abstractions;

public interface IClientHttp
{
    Task<bool> ValidateEmployeeAsync(int employeeId, CancellationToken cancellationToken);
}