using Attendance.Business.Abstractions;
using Attendance.Shared;
using Microsoft.AspNetCore.Mvc;

namespace Attendance.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class AttendanceController(IBusiness business) : ControllerBase
{
    [HttpPost(Name = "CreateAttendance")]
    public async Task<IActionResult> CreateAttendance(CreateAttendanceDto createAttendanceDto,
        CancellationToken cancellationToken)
    {
        var isCreated = await business.CreateAttendance(createAttendanceDto, cancellationToken);
        return isCreated ? Ok() : BadRequest();
    }

    [HttpGet("{attendanceId:int}", Name = "GetAttendanceById")]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetAttendanceById(int attendanceId, CancellationToken cancellationToken)
    {
        var attendance = await business.GetAttendanceById(attendanceId, cancellationToken);
        return attendance is null ? NotFound() : Ok(attendance);
    }

    [HttpPut(Name = "UpdateAttendance")]
    [ProducesResponseType(404)]
    public async Task<IActionResult> UpdateAttendance(UpdateAttendanceDto updateAttendanceDto,
        CancellationToken cancellationToken)
    {
        var isUpdated = await business.UpdateAttendance(updateAttendanceDto, cancellationToken);
        return isUpdated ? Ok() : NotFound();
    }

    [HttpDelete("{attendanceId:int}", Name = "DeleteAttendance")]
    [ProducesResponseType(404)]
    public async Task<IActionResult> DeleteAttendance(int attendanceId, CancellationToken cancellationToken)
    {
        var isDeleted = await business.DeleteAttendance(attendanceId, cancellationToken);
        return isDeleted ? Ok() : NotFound();
    }
    
    [HttpGet(Name = "GetAttendances")]
    public async Task<IActionResult> GetAttendances(CancellationToken cancellationToken)
    {
        var attendances = await business.GetAttendances(cancellationToken);
        return Ok(attendances);
    }
    
    [HttpGet("employee/{employeeId:int}", Name = "GetAttendancesByEmployeeId")]
    public async Task<IActionResult> GetAttendancesByEmployeeId(int employeeId, CancellationToken cancellationToken)
    {
        var attendances = await business.GetAttendancesByEmployeeId(employeeId, cancellationToken);
        return Ok(attendances);
    }
}