using Attendance.Business.Abstractions;
using Attendance.Http.Abstractions;
using Attendance.Repository.Abstractions;
using Attendance.Shared;
using AutoMapper;
using Microsoft.Extensions.Logging;

namespace Attendance.Business;

public class Business(IRepository repository, ILogger<Business> logger, IMapper mapper, IClientHttp clientHttp)
    : IBusiness
{
    public async Task CreateAttendance(CreateAttendanceDto createAttendanceDto,
        CancellationToken cancellationToken = default)
    {
        var employeeExists = await clientHttp.ValidateEmployeeAsync(createAttendanceDto.EmployeeId, cancellationToken);
        if (!employeeExists)
        {
            logger.LogError("Employee with id {employeeId} not found", createAttendanceDto.EmployeeId);
            return;
        }
        var attendance = mapper.Map<Repository.Models.Attendance>(createAttendanceDto);
        await repository.CreateAttendance(attendance, cancellationToken);
        await repository.SaveChangesAsync(cancellationToken);
    }

    public async Task<bool> DeleteAttendance(int attendanceId, CancellationToken cancellationToken = default)
    {
        var isDeleted = await repository.DeleteAttendance(attendanceId, cancellationToken);
        if (!isDeleted)
        {
            logger.LogError("Attendance with id {attendanceId} not found", attendanceId);
            return false;
        }

        await repository.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<bool> UpdateAttendance(UpdateAttendanceDto updateAttendanceDto,
        CancellationToken cancellationToken = default)
    {
        var attendance = await repository.GetAttendanceById(updateAttendanceDto.AttendanceId, cancellationToken);
        if (attendance is null)
        {
            logger.LogError("Attendance with id {attendanceId} not found", updateAttendanceDto.AttendanceId);
            return false;
        }

        mapper.Map(updateAttendanceDto, attendance);
        await repository.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<ReadAttendanceDto?> GetAttendanceById(int attendanceId,
        CancellationToken cancellationToken = default)
    {
        var attendance = await repository.GetAttendanceById(attendanceId, cancellationToken);
        return mapper.Map<ReadAttendanceDto>(attendance);
    }

    public async Task<IEnumerable<ReadAttendanceDto>> GetAttendanceByEmployeeId(int employeeId,
        CancellationToken cancellationToken = default)
    {
        var attendances = await repository.GetAttendancesByEmployeeId(employeeId, cancellationToken);
        return mapper.Map<IEnumerable<ReadAttendanceDto>>(attendances);
    }

    public async Task CreateLeaveRecord(CreateLeaveRecordDto createLeaveRecordDto,
        CancellationToken cancellationToken = default)
    {
        var leaveRecord = mapper.Map<Repository.Models.LeaveRecord>(createLeaveRecordDto);
        await repository.CreateLeaveRecord(leaveRecord, cancellationToken);
        await repository.SaveChangesAsync(cancellationToken);
    }

    public async Task<bool> DeleteLeaveRecord(int leaveRecordId, CancellationToken cancellationToken = default)
    {
        var isDeleted = await repository.DeleteLeaveRecord(leaveRecordId, cancellationToken);
        if (!isDeleted)
        {
            logger.LogError("Leave record with id {leaveRecordId} not found", leaveRecordId);
            return false;
        }

        await repository.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<bool> UpdateLeaveRecord(UpdateLeaveRecordDto updateLeaveRecordDto,
        CancellationToken cancellationToken = default)
    {
        var leaveRecord = await repository.GetLeaveRecordById(updateLeaveRecordDto.LeaveRecordId, cancellationToken);
        if (leaveRecord is null)
        {
            logger.LogError("Leave record with id {leaveRecordId} not found", updateLeaveRecordDto.LeaveRecordId);
            return false;
        }

        mapper.Map(updateLeaveRecordDto, leaveRecord);
        await repository.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<ReadLeaveRecordDto?> GetLeaveRecordById(int leaveRecordId,
        CancellationToken cancellationToken = default)
    {
        var leaveRecord = await repository.GetLeaveRecordById(leaveRecordId, cancellationToken);
        return mapper.Map<ReadLeaveRecordDto>(leaveRecord);
    }

    public async Task<IEnumerable<ReadLeaveRecordDto>> GetLeaveRecordsByEmployeeId(int employeeId,
        CancellationToken cancellationToken = default)
    {
        var leaveRecords = await repository.GetLeaveRecordsByEmployeeId(employeeId, cancellationToken);
        return mapper.Map<IEnumerable<ReadLeaveRecordDto>>(leaveRecords);
    }

    public async Task<bool> ValidateEmployee(int employeeId, CancellationToken cancellationToken = default)
    {
        return await clientHttp.ValidateEmployeeAsync(employeeId, cancellationToken);
    }
}