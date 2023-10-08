using smartLinkTask.DAL.DBContext;
using smartLinkTask.DAL.Models.AttendanceEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smartLinkTask.DAL.Repositories.Attendances
{
    public class AttendanceRepository : IAttendanceRepository
    {
        private readonly HrManagmentContext _hrManagmentContext;
        public AttendanceRepository(HrManagmentContext hrManagmentContext)
        {
            _hrManagmentContext = hrManagmentContext;   
        }
        public async Task AddAttendanceAsync(Attendance attendance)
        {
            await _hrManagmentContext.Attendances.AddAsync(attendance);
            await _hrManagmentContext.SaveChangesAsync();
        }
    }
}
