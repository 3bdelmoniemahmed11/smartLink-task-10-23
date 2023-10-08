using smartLinkTask.DAL.Models.AttendanceEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smartLinkTask.DAL.Repositories.Attendances
{
    public interface IAttendanceRepository
    {
        public Task AddAttendanceAsync(Attendance attendance);
       
    }
}
