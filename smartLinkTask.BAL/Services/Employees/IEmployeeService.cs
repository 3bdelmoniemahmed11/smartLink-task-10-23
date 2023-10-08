using smartLinkTask.DAL.Models.EmployeesEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smartLinkTask.BAL.Services.Employees
{
    public interface IEmployeeService
    {
        public Task AddEmployeeAsync(Employee employee);
        public Task<List<Employee>> GetAllEmployeesAsync();
        public Task<Employee> GetEmployeeByIdAsync(Guid employeeId);
        public Task UpdateEmployeeAsync(Employee employee);
    }
}
