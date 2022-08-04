using AutoMapper;
using Basket.Application.Models;
using Basket.Domain.Entities;

namespace Basket.Application.Profiles
{
    internal class TicketProfile : Profile
    {
        public TicketProfile()
        {
            CreateMap<TicketInfo, Ticket>();
            CreateMap<Ticket, TicketInfo>();
        }
    }
}
