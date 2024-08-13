using Employee.Business.Abstraction;
using Employee.Shared;
using Microsoft.AspNetCore.Mvc;

namespace Employee.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class JobTitleController(IBusiness business, ILogger<JobTitleController> logger) : ControllerBase
{
    [HttpPost(Name = "CreateJobTitle")]
    public async Task<IActionResult> CreateJobTitle(CreateJobTitleDto createJobTitleDto,
        CancellationToken cancellationToken)
    {
        await business.CreateJobTitle(createJobTitleDto, cancellationToken);
        return Ok();
    }

    [HttpGet("{jobTitleId:int}", Name = "GetJobTitleById")]
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
    public async Task<IActionResult> UpdateJobTitle(UpdateJobTitleDto updateJobTitleDto,
        CancellationToken cancellationToken)
    {
        await business.UpdateJobTitle(updateJobTitleDto, cancellationToken);
        return Ok();
    }

    [HttpDelete("{jobTitleId:int}", Name = "DeleteJobTitle")]
    public async Task<IActionResult> DeleteJobTitle(int jobTitleId, CancellationToken cancellationToken)
    {
        await business.DeleteJobTitle(jobTitleId, cancellationToken);
        return Ok();
    }
}