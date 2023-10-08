using smartLinkTask.DAL.Core.Entities;
using smartLinkTask.DAL.Models.EmployeesEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smartLinkTask.DAL.Models.AttendanceEntity
{
    public class Attendance:BaseEntity
    {
      
        public DateTime AttendanceDate { get; set; }
        [ForeignKey("Employee")]
        public Guid EmployeeId { get; set; }    
        public Employee Employee { get; set; }  
    }
}
