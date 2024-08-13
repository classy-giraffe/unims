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
    public async Task<IActionResult> UpdateDepartment(UpdateDepartmentDto updateDepartmentDto,
        CancellationToken cancellationToken)
    {
        await business.UpdateDepartment(updateDepartmentDto, cancellationToken);
        return Ok();
    }

    [HttpDelete("{departmentId:int}", Name = "DeleteDepartment")]
    public async Task<IActionResult> DeleteDepartment(int departmentId, CancellationToken cancellationToken)
    {
        await business.DeleteDepartment(departmentId, cancellationToken);
        return Ok();
    }
}