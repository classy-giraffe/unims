using Microsoft.AspNetCore.Mvc;
using Payroll.Business.Abstractions;
using Payroll.Shared;

namespace Payroll.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class SalaryController(IBusiness business) : ControllerBase
{
    [HttpPost(Name = "CreateSalary")]
    [ProducesResponseType(400)]
    public async Task<IActionResult> CreateSalary(CreateSalaryDto createSalaryDto,
        CancellationToken cancellationToken)
    {
        var isCreated = await business.CreateSalary(createSalaryDto, cancellationToken);
        return isCreated ? Ok() : BadRequest();
    }

    [HttpGet("{salaryId:int}", Name = "GetSalaryById")]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetSalaryById(int salaryId, CancellationToken cancellationToken)
    {
        var salary = await business.GetSalaryById(salaryId, cancellationToken);
        return salary is null ? NotFound() : Ok(salary);
    }

    [HttpGet(Name = "GetSalaries")]
    public async Task<IActionResult> GetSalaries(CancellationToken cancellationToken)
    {
        var salaries = await business.GetSalaries(cancellationToken);
        return Ok(salaries);
    }

    [HttpPut(Name = "UpdateSalary")]
    [ProducesResponseType(404)]
    public async Task<IActionResult> UpdateSalary(UpdateSalaryDto updateSalaryDto, CancellationToken cancellationToken)
    {
        var isUpdated = await business.UpdateSalary(updateSalaryDto, cancellationToken);
        return isUpdated ? Ok() : NotFound();
    }

    [HttpDelete("{salaryId:int}", Name = "DeleteSalary")]
    [ProducesResponseType(404)]
    public async Task<IActionResult> DeleteSalary(int salaryId, CancellationToken cancellationToken)
    {
        var isDeleted = await business.DeleteSalary(salaryId, cancellationToken);
        return isDeleted ? Ok() : NotFound();
    }

    [HttpGet("employee/{employeeId:int}", Name = "GetSalariesByEmployeeId")]
    public async Task<IActionResult> GetSalariesByEmployeeId(int employeeId, CancellationToken cancellationToken)
    {
        var salaries = await business.GetSalariesByEmployeeId(employeeId, cancellationToken);
        return Ok(salaries);
    }
}