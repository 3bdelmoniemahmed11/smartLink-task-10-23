using smartLinkTask.DAL.Models.UserProfileEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smartLinkTask.BAL.Services.Auth.Token
{
    public interface ITokenService
    {
        public string GenerateToken(UserProfile user, List<string> Roles);
    }
}
