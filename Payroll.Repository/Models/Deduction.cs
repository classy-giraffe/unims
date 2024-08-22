namespace Payroll.Repository.Models;

public class Deduction
{
    public int DeductionId { get; set; }
    public string? Description { get; set; }
    public decimal Amount { get; set; }
    public int PayrollId { get; set; }
    public Payroll? Payroll { get; set; }
}