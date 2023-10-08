using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using smartLinkTask.DAL.DBContext;
using smartLinkTask.DAL.Models.EmployeesEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smartLinkTask.DAL.Repositories.Employees
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly HrManagmentContext _hrManagmentContext;
        public EmployeeRepository(HrManagmentContext hrManagmentContext)
        {
            _hrManagmentContext= hrManagmentContext;    
        }
        public async Task  AddEmployeeAsync(Employee employee)
        {
            await _hrManagmentContext.Employees.AddAsync(employee);
            await  _hrManagmentContext.SaveChangesAsync();

        }

        public async Task<Employee> GetEmployeeByIdAsync(Guid employeeId)
        {
            return await _hrManagmentContext.Employees.Where(e => !e.IsDeleted && e.Id == employeeId).FirstOrDefaultAsync();
        }

        public async Task<List<Employee>> GetEmployeesAsync()=> await _hrManagmentContext.Employees.Where(e => !e.IsDeleted).ToListAsync();

        public async Task UpdateEmpoyeeAsync(Employee employee)
        {
            _hrManagmentContext.Employees.Attach(employee);
            _hrManagmentContext.Entry(employee).State = EntityState.Modified;
            _hrManagmentContext.SaveChanges();
        }
    }
}
