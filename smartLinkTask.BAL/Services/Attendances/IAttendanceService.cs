using smartLinkTask.DAL.Models.AttendanceEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smartLinkTask.BAL.Services.Attendances
{
    public interface IAttendanceService
    {
        public Task AddAttendanceAsync(Attendance attendance);
    }
}
