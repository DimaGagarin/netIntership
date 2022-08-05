using AutoMapper;
using Identity.Application.Models;
using Identity.Domain.Entities;

namespace Identity.Application.Profiles
{
    /// <summary>
    /// <see cref="User"/> maping profile.
    /// </summary>
    internal class UserProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserProfile"/> class.
        /// </summary>
        public UserProfile()
        {
            CreateMap<RegisterUserModel, User>();
            CreateMap<User, UserInfo>();
        }
    }
}
