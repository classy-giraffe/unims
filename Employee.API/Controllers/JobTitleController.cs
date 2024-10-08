﻿using Employee.Business.Abstraction;
using Employee.Shared;
using Microsoft.AspNetCore.Mvc;

namespace Employee.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class JobTitleController(IBusiness business, ILogger<JobTitleController> logger) : ControllerBase
{
    [HttpPost(Name = "CreateJobTitle")]
    public async Task<IActionResult> CreateJobTitle(CreateJobTitleDto jobTitleDto,
        CancellationToken cancellationToken)
    {
        await business.CreateJobTitle(jobTitleDto, cancellationToken);
        return Ok();
    }

    [HttpGet("{jobTitleId:int}", Name = "GetJobTitleById")]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetJobTitleById(int jobTitleId, CancellationToken cancellationToken)
    {
        var jobTitle = await business.GetJobTitleById(jobTitleId, cancellationToken);
        return jobTitle is null ? NotFound() : Ok(jobTitle);
    }

    [HttpGet(Name = "GetJobTitles")]
    public async Task<IActionResult> GetJobTitles(CancellationToken cancellationToken)
    {
        var jobTitles = await business.GetJobTitles(cancellationToken);
        return Ok(jobTitles);
    }

    [HttpPut(Name = "UpdateJobTitle")]
    [ProducesResponseType(404)]
    public async Task<IActionResult> UpdateJobTitle(UpdateJobTitleDto updateJobTitleDto,
        CancellationToken cancellationToken)
    {
        var isUpdated = await business.UpdateJobTitle(updateJobTitleDto, cancellationToken);
        return isUpdated ? Ok() : NotFound();
    }

    [HttpDelete("{jobTitleId:int}", Name = "DeleteJobTitle")]
    [ProducesResponseType(404)]
    public async Task<IActionResult> DeleteJobTitle(int jobTitleId, CancellationToken cancellationToken)
    {
        var isDeleted = await business.DeleteJobTitle(jobTitleId, cancellationToken);
        return isDeleted ? Ok() : NotFound();
    }
}