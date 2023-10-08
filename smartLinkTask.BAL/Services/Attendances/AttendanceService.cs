using Microsoft.AspNetCore.Http;
using smartLinkTask.DAL.Models.AttendanceEntity;
using smartLinkTask.DAL.Models.EmployeesEntity;
using smartLinkTask.DAL.Repositories.Attendances;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace smartLinkTask.BAL.Services.Attendances
{
    public class AttendanceService : IAttendanceService
    {
        private readonly IAttendanceRepository _attendanceRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AttendanceService(IAttendanceRepository attendanceRepository, IHttpContextAccessor httpContextAccessor)
        {
            _attendanceRepository= attendanceRepository;
            _httpContextAccessor= httpContextAccessor;
        }
        public async Task AddAttendanceAsync(Attendance attendance)
        {
            attendance.CreationDate = DateTime.UtcNow;
            var id = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
            attendance.CreatedByUserId = new Guid(id.Value);
            await _attendanceRepository.AddAttendanceAsync(attendance);
        }

        
    }
}
