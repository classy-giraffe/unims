using Attendance.Repository.Models;
using Attendance.Shared;
using AutoMapper;

namespace Attendance.Business.Profiles;

public class AttendanceProfiles : Profile
{
    public AttendanceProfiles()
    {
        CreateMap<CreateAttendanceDto, Repository.Models.Attendance>().ReverseMap();
        CreateMap<UpdateAttendanceDto, Repository.Models.Attendance>().ReverseMap();
        CreateMap<ReadAttendanceDto, Repository.Models.Attendance>().ReverseMap();
        CreateMap<CreateLeaveRecordDto, LeaveRecord>().ReverseMap();
        CreateMap<UpdateLeaveRecordDto, LeaveRecord>().ReverseMap();
        CreateMap<ReadLeaveRecordDto, LeaveRecord>().ReverseMap();
    }
}