using Employee.Business.Abstraction;
using Employee.Shared;
using Microsoft.AspNetCore.Mvc;

namespace Employee.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class EmployeeController(IBusiness business) : ControllerBase
{
    [HttpPost(Name = "CreateEmployee")]
    public async Task<IActionResult> CreateEmployee(CreateEmployeeDto employeeDto,
        CancellationToken cancellationToken)
    {
        await business.CreateEmployee(employeeDto, cancellationToken);
        return Ok();
    }

    [HttpGet("{employeeId:int}", Name = "GetEmployeeById")]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetEmployeeById(int employeeId, CancellationToken cancellationToken)
    {
        var employee = await business.GetEmployeeById(employeeId, cancellationToken);
        return employee is null ? NotFound() : Ok(employee);
    }

    [HttpGet(Name = "GetEmployees")]
    public async Task<IActionResult> GetEmployees(CancellationToken cancellationToken)
    {
        var employees = await business.GetEmployees(cancellationToken);
        return Ok(employees);
    }

    [HttpPut(Name = "UpdateEmployee")]
    [ProducesResponseType(404)]
    public async Task<IActionResult> UpdateEmployee(UpdateEmployeeDto updateEmployeeDto,
        CancellationToken cancellationToken)
    {
        var isUpdated = await business.UpdateEmployee(updateEmployeeDto, cancellationToken);
        return isUpdated ? Ok() : NotFound();
    }

    [HttpDelete("{employeeId:int}", Name = "DeleteEmployee")]
    [ProducesResponseType(404)]
    public async Task<IActionResult> DeleteEmployee(int employeeId, CancellationToken cancellationToken)
    {
        var isDeleted = await business.DeleteEmployee(employeeId, cancellationToken);
        return isDeleted ? Ok() : NotFound();
    }

    [HttpGet("Department/{departmentId:int}", Name = "GetEmployeesByDepartment")]
    public async Task<IActionResult> GetEmployeesByDepartment(int departmentId, CancellationToken cancellationToken)
    {
        var employees = await business.GetEmployeesByDepartment(departmentId, cancellationToken);
        return Ok(employees);
    }

    [HttpGet("JobTitle/{jobTitleId:int}", Name = "GetEmployeesByJobTitle")]
    public async Task<IActionResult> GetEmployeesByJobTitle(int jobTitleId, CancellationToken cancellationToken)
    {
        var employees = await business.GetEmployeesByJobTitle(jobTitleId, cancellationToken);
        return Ok(employees);
    }

    [HttpGet("HireDate/{hireDate:datetime}", Name = "GetEmployeesByHireDate")]
    public async Task<IActionResult> GetEmployeesByHireDate(DateTime hireDate, CancellationToken cancellationToken)
    {
        var employees = await business.GetEmployeesByHireDate(hireDate, cancellationToken);
        return Ok(employees);
    }
}