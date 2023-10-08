using smartLinkTask.DAL.Core.Entities;
using smartLinkTask.DAL.Models.AttendanceEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smartLinkTask.DAL.Models.EmployeesEntity
{
    public class Employee:BaseEntity
    {
        public string Name { get; set; }
        public string Group { get; set; }
        
    }
    
}
