using Payroll.Http.Abstractions;

namespace Payroll.Http;

public class ClientHttp(HttpClient httpClient) : IClientHttp
{
    public async Task<bool> ValidateEmployeeAsync(int employeeId, CancellationToken cancellationToken)
    {
        var response = await httpClient.GetAsync($"api/v1/Employee/{employeeId}", cancellationToken);
        return response.IsSuccessStatusCode;
    }
}