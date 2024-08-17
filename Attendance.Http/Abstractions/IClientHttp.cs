namespace Attendance.Http.Abstractions;

public interface IClientHttp
{
    public Task<bool> ValidateEmployeeAsync(int employeeId, CancellationToken cancellationToken = default);
}