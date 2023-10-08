using smartLinkTask.DAL.Models.EmployeesEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smartLinkTask.DAL.Repositories.Employees
{
    public interface IEmployeeRepository
    {
        public Task  AddEmployeeAsync(Employee employee);
        public Task<List<Employee>> GetEmployeesAsync();
        public Task UpdateEmpoyeeAsync(Employee employee);
        public Task<Employee> GetEmployeeByIdAsync(Guid employeeId);
    
    }
}
