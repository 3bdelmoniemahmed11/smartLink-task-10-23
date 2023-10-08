using smartLinkTask.DAL.Models.UserProfileEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smartLinkTask.BAL.Services.Account.Login
{
    public interface ILoginService
    {
        public Task<string> LoginAsync(LoginData loginData);
    }
}
