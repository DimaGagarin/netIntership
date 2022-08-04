using AutoMapper;
using Identity.Application.Models;
using Identity.Domain.Entities;

namespace Identity.Application.Profiles
{
    internal class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<RegisterUserModel, User>();
            CreateMap<User, UserInfo>();
        }
    }
}
