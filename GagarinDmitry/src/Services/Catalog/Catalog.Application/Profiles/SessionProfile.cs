using AutoMapper;
using Catalog.Application.Models;
using Catalog.Domain.Entities;

namespace Catalog.Application.Profiles
{
    internal class SessionProfile : Profile
    {
        public SessionProfile()
        {
            CreateMap<Session, GetSessionModel>();
        }
    }
}
