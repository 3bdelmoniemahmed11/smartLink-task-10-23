using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using smartLinkTask.BAL.Services.Employees;
using smartLinkTask.Controllers.Employees.DTO;
using smartLinkTask.Core.enums;
using smartLinkTask.DAL.Models.EmployeesEntity;
using smartLinkTask.DAL.Models.UserProfileEntity;

namespace smartLinkTask.Controllers.Employees
{
    [Route("api/[controller]")]
  
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly UserManager<UserProfile> _userManager;
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;

        public EmployeeController(UserManager<UserProfile> userManager, IEmployeeService employeeService, IMapper mapper)
        {
            _userManager = userManager; 
            _employeeService = employeeService; 
            _mapper = mapper;   
        }


        [HttpPost]
        [Authorize(Roles = "HR")]
        public async Task<IActionResult> AddEmployeeAsync([FromBody] CreateEmployeeDTO employee)
        {
           if(employee!=null)
            {
                if (employee.Group == Roles.HR)
                {
                    var user = new UserProfile { UserName = employee.Email, Email = employee.Email };
                    employee.Id = new Guid(user.Id);
                    var result = await _userManager.CreateAsync(user, employee.Password);
                    if (result.Succeeded) await _userManager.AddToRoleAsync(user, Roles.HR);

                }
                var employeeEntity = _mapper.Map<Employee>(employee);
                await _employeeService.AddEmployeeAsync(employeeEntity);
                return Ok(employee);
            }

            return BadRequest();
        }


       [HttpGet]
       [Authorize(Roles = "HR")]
        public async Task<IActionResult> GetEmployeesAsync()
        {
            var employees = await _employeeService.GetAllEmployeesAsync();
            var entities = _mapper.Map<List<GetEmployeeDTO>>(employees);
            if (employees != null) return Ok(entities);
            return BadRequest("smething wrong ");
        }

        [HttpGet("find")]
        [Authorize(Roles = "HR")]
        public async Task<IActionResult> GetEmployeesByIdAsync(Guid employeeId)
        {
           var employee = await _employeeService.GetEmployeeByIdAsync(employeeId);
            var entity = _mapper.Map<GetEmployeeDTO>(employee);
            if (employee != null) return Ok(entity);
            return BadRequest("smething wrong ");

        }

        [HttpPut()]
        [Authorize(Roles = "HR")]
        public async Task<IActionResult> UpdateEmployeesAsync([FromBody] UpdateEmployeeDTO employeeDTO)
        {
            var employeeEntity = await _employeeService.GetEmployeeByIdAsync(employeeDTO.Id);

            employeeEntity = _mapper.Map<UpdateEmployeeDTO, Employee>(employeeDTO, employeeEntity);
            await _employeeService.UpdateEmployeeAsync(employeeEntity);
            if (employeeDTO != null) 
                return Ok(employeeEntity);
            return BadRequest("something wrong ");

        }
    }


    }

