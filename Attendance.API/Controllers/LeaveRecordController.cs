using Attendance.Business.Abstractions;
using Attendance.Shared;
using Microsoft.AspNetCore.Mvc;

namespace Attendance.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class LeaveRecordController(IBusiness business) : ControllerBase
{
    [HttpPost(Name = "CreateLeaveRecord")]
    public async Task<IActionResult> CreateLeaveRecord(CreateLeaveRecordDto createLeaveRecordDto,
        CancellationToken cancellationToken)
    {
        var isCreated = await business.CreateLeaveRecord(createLeaveRecordDto, cancellationToken);
        return isCreated ? Ok() : BadRequest();
    }

    [HttpGet("{leaveRecordId:int}", Name = "GetLeaveRecordById")]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetLeaveRecordById(int leaveRecordId, CancellationToken cancellationToken)
    {
        var leaveRecord = await business.GetLeaveRecordById(leaveRecordId, cancellationToken);
        return leaveRecord is null ? NotFound() : Ok(leaveRecord);
    }

    [HttpPut(Name = "UpdateLeaveRecord")]
    [ProducesResponseType(404)]
    public async Task<IActionResult> UpdateLeaveRecord(UpdateLeaveRecordDto updateLeaveRecordDto,
        CancellationToken cancellationToken)
    {
        var isUpdated = await business.UpdateLeaveRecord(updateLeaveRecordDto, cancellationToken);
        return isUpdated ? Ok() : NotFound();
    }

    [HttpDelete("{leaveRecordId:int}", Name = "DeleteLeaveRecord")]
    [ProducesResponseType(404)]
    public async Task<IActionResult> DeleteLeaveRecord(int leaveRecordId, CancellationToken cancellationToken)
    {
        var isDeleted = await business.DeleteLeaveRecord(leaveRecordId, cancellationToken);
        return isDeleted ? Ok() : NotFound();
    }

    [HttpGet(Name = "GetLeaveRecords")]
    public async Task<IActionResult> GetLeaveRecords(CancellationToken cancellationToken)
    {
        var leaveRecords = await business.GetLeaveRecords(cancellationToken);
        return Ok(leaveRecords);
    }

    [HttpGet("employee/{employeeId:int}", Name = "GetLeaveRecordsByEmployeeId")]
    public async Task<IActionResult> GetLeaveRecordsByEmployeeId(int employeeId, CancellationToken cancellationToken)
    {
        var leaveRecords = await business.GetLeaveRecordsByEmployeeId(employeeId, cancellationToken);
        return Ok(leaveRecords);
    }
}