using AutoMapper;
using Payroll.Repository.Models;
using Payroll.Shared;

namespace Payroll.Business.Profiles;

public class PayrollProfiles : Profile
{
    public PayrollProfiles()
    {
        CreateMap<CreatePayrollDto, Repository.Models.Payroll>().ReverseMap();
        CreateMap<UpdatePayrollDto, Repository.Models.Payroll>().ReverseMap();
        CreateMap<ReadPayrollDto, Repository.Models.Payroll>().ReverseMap();

        CreateMap<CreateSalaryDto, Salary>().ReverseMap();
        CreateMap<UpdateSalaryDto, Salary>().ReverseMap();
        CreateMap<ReadSalaryDto, Salary>().ReverseMap();

        CreateMap<CreateDeductionDto, Deduction>().ReverseMap();
        CreateMap<UpdateDeductionDto, Deduction>().ReverseMap();
        CreateMap<ReadDeductionDto, Deduction>().ReverseMap();
    }
}