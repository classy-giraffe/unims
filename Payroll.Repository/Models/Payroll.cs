namespace Payroll.Repository.Models;

public class Payroll
{
    public int PayrollId { get; set; }
    public int EmployeeId { get; set; }
    public decimal GrossSalary { get; set; }
    public decimal NetSalary { get; set; }
    public DateTime PayrollDate { get; set; }
    public ICollection<Deduction> Deductions { get; set; } = new List<Deduction>();
}