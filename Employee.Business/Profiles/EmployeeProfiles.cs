using AutoMapper;
using Employee.Repository.Models;
using Employee.Shared;

namespace Employee.Business.Profiles;

public class EmployeeProfiles : Profile
{
    public EmployeeProfiles()
    {
        CreateMap<CreateEmployeeDto, Repository.Models.Employee>().ReverseMap();
        CreateMap<UpdateEmployeeDto, Repository.Models.Employee>().ReverseMap();
        CreateMap<ReadEmployeeDto, Repository.Models.Employee>().ReverseMap();

        CreateMap<CreateJobTitleDto, JobTitle>().ReverseMap();
        CreateMap<UpdateJobTitleDto, JobTitle>().ReverseMap();
        CreateMap<ReadJobTitleDto, JobTitle>().ReverseMap();

        CreateMap<CreateDepartmentDto, Department>().ReverseMap();
        CreateMap<UpdateDepartmentDto, Department>().ReverseMap();
        CreateMap<ReadDepartmentDto, Department>().ReverseMap();
    }
}