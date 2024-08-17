using Attendance.Repository.Models;
using Attendance.Shared;
using AutoMapper;

namespace Attendance.Business.Profiles;

public class AttendanceProfiles : Profile
{
    public AttendanceProfiles()
    {
        CreateMap<CreateAttendanceDto, Attendance.Repository.Models.Attendance>().ReverseMap();
        CreateMap<UpdateAttendanceDto, Attendance.Repository.Models.Attendance>().ReverseMap();
        CreateMap<ReadAttendanceDto, Attendance.Repository.Models.Attendance>().ReverseMap();
        CreateMap<DeleteAttendanceDto, Attendance.Repository.Models.Attendance>().ReverseMap();

        CreateMap<CreateLeaveRecordDto, LeaveRecord>().ReverseMap();
        CreateMap<UpdateLeaveRecordDto, LeaveRecord>().ReverseMap();
        CreateMap<ReadLeaveRecordDto, LeaveRecord>().ReverseMap();
        CreateMap<DeleteLeaveRecordDto, LeaveRecord>().ReverseMap();
    }
}