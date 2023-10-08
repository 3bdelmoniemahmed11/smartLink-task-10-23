using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using smartLinkTask.BAL.Services.Attendances;
using smartLinkTask.Controllers.Attendances.DTO;
using smartLinkTask.DAL.Models.AttendanceEntity;


namespace smartLinkTask.Controllers.Attendances
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAttendanceService _attendanceService;
        public AttendanceController(IMapper mapper, IAttendanceService attendanceService)
        {
            _mapper=mapper;
            _attendanceService=attendanceService;   
        }

        [HttpPost]
        [Authorize(Roles = "HR")]
        public async Task<IActionResult> AddEmployeeAttendanceAsync([FromBody] CreateAttendanceDTO attendance)
        {

            if (attendance != null)
            {
                var attendanceEntity = _mapper.Map<Attendance>(attendance);
                await _attendanceService.AddAttendanceAsync(attendanceEntity);
                return Ok();
            }

            return BadRequest();
        }

    }
}
