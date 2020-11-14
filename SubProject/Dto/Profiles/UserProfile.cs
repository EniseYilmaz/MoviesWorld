using AutoMapper;
using DataServiceLib.Models;

namespace SubProject.Dto.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>();
        }

    }
}
