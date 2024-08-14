using System.ComponentModel;
using System.Diagnostics;
using Employee.Business.Abstraction;
using Employee.Shared;
using Microsoft.AspNetCore.Mvc;

namespace Employee.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class DepartmentController(IBusiness business, ILogger<DepartmentController> logger) : ControllerBase
{
    [HttpPost(Name = "CreateDepartment")]
    public async Task<IActionResult> CreateDepartment(CreateDepartmentDto createDepartmentDto,
        CancellationToken cancellationToken)
    {
        await business.CreateDepartment(createDepartmentDto, cancellationToken);
        return Ok();
    }

    [HttpGet("{departmentId:int}", Name = "GetDepartmentById")]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetDepartmentById(int departmentId, CancellationToken cancellationToken)
    {
        var department = await business.GetDepartmentById(departmentId, cancellationToken);
        return department is null ? NotFound() : Ok(department);
    }

    [HttpGet(Name = "GetDepartments")]
    public async Task<IActionResult> GetDepartments(CancellationToken cancellationToken)
    {
        var departments = await business.GetDepartments(cancellationToken);
        return Ok(departments);
    }

    [HttpPut(Name = "UpdateDepartment")]
    [ProducesResponseType(404)]
    public async Task<IActionResult> UpdateDepartment(UpdateDepartmentDto updateDepartmentDto,
        CancellationToken cancellationToken)
    {
        var isUpdated = await business.UpdateDepartment(updateDepartmentDto, cancellationToken);
        return isUpdated ? Ok() : NotFound();
    }

    [HttpDelete("{departmentId:int}", Name = "DeleteDepartment")]
    [ProducesResponseType(404)]
    public async Task<IActionResult> DeleteDepartment(int departmentId, CancellationToken cancellationToken)
    {
        var isDeleted = await business.DeleteDepartment(departmentId, cancellationToken);
        return isDeleted ? Ok() : NotFound();
    }
}