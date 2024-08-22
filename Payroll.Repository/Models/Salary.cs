namespace Payroll.Repository.Models;

public class Salary
{
    public int SalaryId { get; set; }
    public int EmployeeId { get; set; }
    public decimal BaseSalary { get; set; }
    public DateTime EffectiveDate { get; set; }
}