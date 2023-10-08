using AutoMapper;
using smartLinkTask.Controllers.Account.DTOs;
using smartLinkTask.DAL.Models.UserProfileEntity;

namespace smartLinkTask.Controllers.Account.Mapping
{
    public class AccountMappingProfile:Profile
    {
        public AccountMappingProfile()
        {
            CreateMap<LoginDTO, LoginData>();
        }
    }
}
