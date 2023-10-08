using AutoMapper;
using smartLinkTask.Controllers.Employees.DTO;
using smartLinkTask.DAL.Models.EmployeesEntity;

namespace smartLinkTask.Controllers.Employees.Mapping
{
    public class EmployeeMappingProfile:Profile
    {
        public EmployeeMappingProfile()
        {
            CreateMap<CreateEmployeeDTO, Employee>();
            CreateMap<Employee, GetEmployeeDTO>();
            CreateMap<UpdateEmployeeDTO, Employee>();

        }
    }
}
