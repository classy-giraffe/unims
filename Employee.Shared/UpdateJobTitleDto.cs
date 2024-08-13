namespace Employee.Shared;

public class UpdateJobTitleDto
{
    public int JobTitleId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
}