using AutoMapper;
using smartLinkTask.Controllers.Attendances.DTO;
using smartLinkTask.DAL.Models.AttendanceEntity;

namespace smartLinkTask.Controllers.Attendances.Mapping
{
    public class AttendanceMappingProfile:Profile
    {
        public AttendanceMappingProfile()
        {
            CreateMap<CreateAttendanceDTO, Attendance>();
        }
    }
}
