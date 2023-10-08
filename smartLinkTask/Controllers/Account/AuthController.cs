using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using smartLinkTask.BAL.Services.Account.Login;
using smartLinkTask.Controllers.Account.DTOs;
using smartLinkTask.DAL.Models.UserProfileEntity;

namespace smartLinkTask.Controllers.Account

{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    { 
        private readonly ILoginService _loginService;
        private readonly IMapper _mapper;
       
        public AuthController( ILoginService loginService, IMapper mapper)
        { 
            _loginService= loginService; 
            _mapper= mapper;    
        }


        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDTO model)
        {
           var LoginData=_mapper.Map<LoginData>(model);
          
           var token= await  _loginService.LoginAsync(LoginData);
            if (!String.IsNullOrEmpty(token)) {
                return Ok(new { Token = token });
            }else
            {
                return Unauthorized("Invalid username or password.");
            }
        }
    }
}

