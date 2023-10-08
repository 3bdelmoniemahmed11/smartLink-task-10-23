using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using smartLinkTask.DAL.Models.AttendanceEntity;
using smartLinkTask.DAL.Models.EmployeesEntity;
using smartLinkTask.DAL.Models.UserProfileEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smartLinkTask.DAL.DBContext
{
    public class HrManagmentContext:IdentityDbContext<UserProfile>
    {
        public HrManagmentContext(DbContextOptions<HrManagmentContext> options) : base(options) { }

       public  DbSet<Employee> Employees { get; set; }
        public DbSet<Attendance> Attendances { get; set; }   

    }
}
