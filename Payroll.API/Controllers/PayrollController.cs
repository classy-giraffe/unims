using Microsoft.AspNetCore.Mvc;
using Payroll.Business.Abstractions;
using Payroll.Shared;

namespace Payroll.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class PayrollController(IBusiness business) : ControllerBase
{
    [HttpPost(Name = "CreatePayroll")]
    [ProducesResponseType(400)]
    public async Task<IActionResult> CreatePayroll(CreatePayrollDto createPayrollDto,
        CancellationToken cancellationToken)
    {
        var isCreated = await business.CreatePayroll(createPayrollDto, cancellationToken);
        return isCreated ? Ok() : BadRequest();
    }

    [HttpGet("{payrollId:int}", Name = "GetPayrollById")]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetPayrollById(int payrollId, CancellationToken cancellationToken)
    {
        var payroll = await business.GetPayrollById(payrollId, cancellationToken);
        return payroll is null ? NotFound() : Ok(payroll);
    }

    [HttpGet(Name = "GetPayrolls")]
    public async Task<IActionResult> GetPayrolls(CancellationToken cancellationToken)
    {
        var payrolls = await business.GetPayrolls(cancellationToken);
        return Ok(payrolls);
    }

    [HttpPut(Name = "UpdatePayroll")]
    [ProducesResponseType(404)]
    public async Task<IActionResult> UpdatePayroll(UpdatePayrollDto updatePayrollDto,
        CancellationToken cancellationToken)
    {
        var isUpdated = await business.UpdatePayroll(updatePayrollDto, cancellationToken);
        return isUpdated ? Ok() : NotFound();
    }

    [HttpDelete("{payrollId:int}", Name = "DeletePayroll")]
    [ProducesResponseType(404)]
    public async Task<IActionResult> DeletePayroll(int payrollId, CancellationToken cancellationToken)
    {
        var isDeleted = await business.DeletePayroll(payrollId, cancellationToken);
        return isDeleted ? Ok() : NotFound();
    }

    [HttpGet("employee/{employeeId:int}", Name = "GetPayrollsByEmployeeId")]
    public async Task<IActionResult> GetPayrollsByEmployeeId(int employeeId, CancellationToken cancellationToken)
    {
        var payrolls = await business.GetPayrollsByEmployeeId(employeeId, cancellationToken);
        return Ok(payrolls);
    }
}