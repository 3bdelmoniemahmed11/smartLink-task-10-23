using Microsoft.AspNetCore.Http;
using smartLinkTask.DAL.Models.EmployeesEntity;
using smartLinkTask.DAL.Repositories.Employees;
using System.Security.Claims;


namespace smartLinkTask.BAL.Services.Employees
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
      
        private readonly IHttpContextAccessor _httpContextAccessor;

        public EmployeeService(
            IEmployeeRepository employeeRepository,
            IHttpContextAccessor httpContextAccessor)
        {
            _employeeRepository= employeeRepository;
            _httpContextAccessor= httpContextAccessor;

        }
        public async Task AddEmployeeAsync(Employee employee)
        {
    
            if(employee.Id ==Guid.Empty) employee.Id = new Guid();
            employee.CreationDate = DateTime.UtcNow;
            var id = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
            employee.CreatedByUserId = new Guid(id.Value);
             await _employeeRepository.AddEmployeeAsync(employee);
        }

        public async Task<List<Employee>> GetAllEmployeesAsync() => await _employeeRepository.GetEmployeesAsync();

        public async Task<Employee> GetEmployeeByIdAsync(Guid employeeId) => await _employeeRepository.GetEmployeeByIdAsync(employeeId);

        public async Task UpdateEmployeeAsync(Employee employee)
        {
            employee.LastModificationDate = DateTime.UtcNow;
            var id = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
            employee.LastModifiedByUserId = new Guid(id.Value);
            employee.LastModificationDate = DateTime.UtcNow;
            await _employeeRepository.UpdateEmpoyeeAsync(employee);
        }
        
    }
}
