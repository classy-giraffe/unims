﻿using AutoMapper;
using Employee.Business.Abstraction;
using Employee.Repository.Abstraction;
using Employee.Repository.Models;
using Employee.Shared;
using KafkaFlow.Producers;
using Microsoft.Extensions.Logging;
using Payroll.Shared;
using CreateEmployeeDto = Employee.Shared.CreateEmployeeDto;

namespace Employee.Business;

public class Business(
    IRepository repository,
    ILogger<Business> logger,
    IMapper mapper,
    IProducerAccessor producerAccessor) : IBusiness
{
    public async Task CreateJobTitle(CreateJobTitleDto jobTitleDto, CancellationToken cancellationToken)
    {
        var jobTitle = mapper.Map<JobTitle>(jobTitleDto);
        await repository.CreateJobTitle(jobTitle, cancellationToken);
        await repository.SaveChangesAsync(cancellationToken);
    }

    public async Task<bool> DeleteJobTitle(int jobTitleId, CancellationToken cancellationToken)
    {
        var isDeleted = await repository.DeleteJobTitle(jobTitleId, cancellationToken);
        if (!isDeleted)
        {
            logger.LogError("Job title with id {jobTitleId} not found", jobTitleId);
            return false;
        }

        await repository.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<bool> DeleteDepartment(int departmentId, CancellationToken cancellationToken)
    {
        var isDeleted = await repository.DeleteDepartment(departmentId, cancellationToken);
        if (!isDeleted)
        {
            logger.LogError("Department with id {departmentId} not found", departmentId);
            return false;
        }

        await repository.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<bool> UpdateJobTitle(UpdateJobTitleDto updateJobTitleDto, CancellationToken cancellationToken)
    {
        var jobTitle = await repository.GetJobTitleById(updateJobTitleDto.JobTitleId, cancellationToken);
        if (jobTitle is null)
        {
            logger.LogError("Job title with id {jobTitleId} not found", updateJobTitleDto.JobTitleId);
            return false;
        }

        mapper.Map(updateJobTitleDto, jobTitle);
        await repository.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<IEnumerable<ReadJobTitleDto>> GetJobTitles(CancellationToken cancellationToken)
    {
        var jobTitles = await repository.GetJobTitles(cancellationToken);
        return jobTitles.Select(mapper.Map<ReadJobTitleDto>);
    }

    public async Task<ReadJobTitleDto?> GetJobTitleById(int jobTitleId, CancellationToken cancellationToken)
    {
        var jobTitle = await repository.GetJobTitleById(jobTitleId, cancellationToken);
        if (jobTitle is not null) return mapper.Map<ReadJobTitleDto>(jobTitle);
        logger.LogError("Job title with id {jobTitleId} not found", jobTitleId);
        return null;
    }

    public async Task CreateEmployee(CreateEmployeeDto employeeDto, CancellationToken cancellationToken)
    {
        var employee = mapper.Map<Repository.Models.Employee>(employeeDto);

        await repository.CreateEmployee(employee, cancellationToken);
        await repository.SaveChangesAsync(cancellationToken);

        logger.LogInformation("Employee with id {employeeId} created on Database", employee.EmployeeId);

        var producer = producerAccessor.GetProducer("employee-producer");

        var employeeEvent = new EmployeeEvent
        {
            Id = employee.EmployeeId,
            Event = Event.Created
        };

        await producer.ProduceAsync("employee-event-topic", Guid.NewGuid().ToString(), employeeEvent);
        logger.LogInformation("Employee with id {employeeId} has been published to Kafka", employee.EmployeeId);
    }

    public async Task<ReadEmployeeDto?> GetEmployeeById(int employeeId, CancellationToken cancellationToken)
    {
        var employee = await repository.GetEmployeeById(employeeId, cancellationToken);
        if (employee is not null) return mapper.Map<ReadEmployeeDto>(employee);
        logger.LogError("Employee with id {employeeId} not found", employeeId);
        return null;
    }

    public async Task<IEnumerable<ReadEmployeeDto>> GetEmployees(CancellationToken cancellationToken)
    {
        var employees = await repository.GetEmployees(cancellationToken);
        return employees.Select(mapper.Map<ReadEmployeeDto>);
    }

    public async Task<bool> UpdateEmployee(UpdateEmployeeDto updateEmployeeDto, CancellationToken cancellationToken)
    {
        var employee = await repository.GetEmployeeById(updateEmployeeDto.EmployeeId, cancellationToken);
        if (employee is null)
        {
            logger.LogError("Employee with id {employeeId} not found", updateEmployeeDto.EmployeeId);
            return false;
        }

        mapper.Map(updateEmployeeDto, employee);
        await repository.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<bool> DeleteEmployee(int employeeId, CancellationToken cancellationToken)
    {
        var isDeleted = await repository.DeleteEmployee(employeeId, cancellationToken);
        if (!isDeleted)
        {
            logger.LogError("Employee with id {employeeId} not found", employeeId);
            return false;
        }

        await repository.SaveChangesAsync(cancellationToken);
        var producer = producerAccessor.GetProducer("employee-producer");
        var employeeEvent = new EmployeeEvent
        {
            Id = employeeId,
            Event = Event.Deleted
        };
        await producer.ProduceAsync("employee-event-topic", Guid.NewGuid().ToString(), employeeEvent);
        logger.LogInformation("Employee with id {employeeId} has been published to Kafka", employeeId);
        return true;
    }

    public async Task<IEnumerable<ReadEmployeeDto>> GetEmployeesByDepartment(int departmentId,
        CancellationToken cancellationToken)
    {
        var employees = await repository.GetEmployeesByDepartment(departmentId, cancellationToken);
        return employees.Select(mapper.Map<ReadEmployeeDto>);
    }

    public async Task<IEnumerable<ReadEmployeeDto>> GetEmployeesByJobTitle(int jobTitleId,
        CancellationToken cancellationToken)
    {
        var employees = await repository.GetEmployeesByJobTitle(jobTitleId, cancellationToken);
        return employees.Select(mapper.Map<ReadEmployeeDto>);
    }

    public async Task<IEnumerable<ReadEmployeeDto>> GetEmployeesByHireDate(DateTime hireDate,
        CancellationToken cancellationToken)
    {
        var employees = await repository.GetEmployeesByHireDate(hireDate, cancellationToken);
        return employees.Select(mapper.Map<ReadEmployeeDto>);
    }

    public async Task CreateDepartment(CreateDepartmentDto departmentDto, CancellationToken cancellationToken)
    {
        var department = mapper.Map<Department>(departmentDto);
        await repository.CreateDepartment(department, cancellationToken);
        await repository.SaveChangesAsync(cancellationToken);
    }

    public async Task<ReadDepartmentDto?> GetDepartmentById(int departmentId, CancellationToken cancellationToken)
    {
        var department = await repository.GetDepartmentById(departmentId, cancellationToken);
        if (department is not null) return mapper.Map<ReadDepartmentDto>(department);
        logger.LogError("Department with id {departmentId} not found", departmentId);
        return null;
    }

    public async Task<IEnumerable<ReadDepartmentDto>> GetDepartments(CancellationToken cancellationToken)
    {
        var departments = await repository.GetDepartments(cancellationToken);
        return departments.Select(mapper.Map<ReadDepartmentDto>);
    }

    public async Task<bool> UpdateDepartment(UpdateDepartmentDto updateDepartmentDto,
        CancellationToken cancellationToken)
    {
        var department = await repository.GetDepartmentById(updateDepartmentDto.DepartmentId, cancellationToken);
        if (department is null)
        {
            logger.LogError("Department with id {departmentId} not found", updateDepartmentDto.DepartmentId);
            return false;
        }

        mapper.Map(updateDepartmentDto, department);
        await repository.SaveChangesAsync(cancellationToken);
        return true;
    }
}