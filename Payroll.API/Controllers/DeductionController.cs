using Microsoft.AspNetCore.Mvc;
using Payroll.Business.Abstractions;
using Payroll.Shared;

namespace Payroll.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class DeductionController(IBusiness business) : ControllerBase
{
    [HttpPost(Name = "CreateDeduction")]
    public async Task<IActionResult> CreateDeduction(CreateDeductionDto createDeductionDto,
        CancellationToken cancellationToken)
    {
        await business.CreateDeduction(createDeductionDto, cancellationToken);
        return Ok();
    }

    [HttpGet("{deductionId:int}", Name = "GetDeductionById")]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetDeductionById(int deductionId, CancellationToken cancellationToken)
    {
        var deduction = await business.GetDeductionById(deductionId, cancellationToken);
        return deduction is null ? NotFound() : Ok(deduction);
    }

    [HttpGet(Name = "GetDeductions")]
    public async Task<IActionResult> GetDeductions(CancellationToken cancellationToken)
    {
        var deductions = await business.GetDeductions(cancellationToken);
        return Ok(deductions);
    }

    [HttpPut(Name = "UpdateDeduction")]
    [ProducesResponseType(404)]
    public async Task<IActionResult> UpdateDeduction(UpdateDeductionDto updateDeductionDto,
        CancellationToken cancellationToken)
    {
        var isUpdated = await business.UpdateDeduction(updateDeductionDto, cancellationToken);
        return isUpdated ? Ok() : NotFound();
    }

    [HttpDelete("{deductionId:int}", Name = "DeleteDeduction")]
    [ProducesResponseType(404)]
    public async Task<IActionResult> DeleteDeduction(int deductionId, CancellationToken cancellationToken)
    {
        var isDeleted = await business.DeleteDeduction(deductionId, cancellationToken);
        return isDeleted ? Ok() : NotFound();
    }

    [HttpGet("payroll/{payrollId:int}", Name = "GetDeductionsByPayrollId")]
    public async Task<IActionResult> GetDeductionsByPayrollId(int payrollId, CancellationToken cancellationToken)
    {
        var deductions = await business.GetDeductionsByPayrollId(payrollId, cancellationToken);
        return Ok(deductions);
    }
}