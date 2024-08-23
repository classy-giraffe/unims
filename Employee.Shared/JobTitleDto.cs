namespace Employee.Shared;

public class CreateJobTitleDto
{
    public string? Name { get; set; }
    public string? Description { get; set; }
}

public class ReadJobTitleDto
{
    public int JobTitleId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
}

public class UpdateJobTitleDto
{
    public int JobTitleId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
}