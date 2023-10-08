using Microsoft.AspNetCore.Identity;
using smartLinkTask.BAL.Services.Auth.Token;
using smartLinkTask.DAL.Core.enums;
using smartLinkTask.DAL.Models.UserProfileEntity;


namespace smartLinkTask.BAL.Services.Account.Login
{
    public class LoginService : ILoginService

    {
        private readonly UserManager<UserProfile> _usermanager;
        private readonly ITokenService _tokenService;
        public LoginService(ITokenService tokenService, UserManager<UserProfile> usermanager)
        {
            _tokenService= tokenService;
            _usermanager= usermanager;  
        }

        public async Task<string> LoginAsync(LoginData model)
        {
            var token="";
            var user = await _usermanager.FindByEmailAsync(model.Email);
            if (user != null && await _usermanager.CheckPasswordAsync(user, model.Password))
            {
                var roles = await _usermanager.GetRolesAsync(user);
                if (roles.Contains(Roles.HR)) token = _tokenService.GenerateToken(user, (List<string>)roles);
            
            }
            return token;
        }
        }
}
