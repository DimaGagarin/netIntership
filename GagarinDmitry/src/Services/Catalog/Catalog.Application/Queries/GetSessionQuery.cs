using Catalog.Application.Models;
using Catalog.Domain.Entities;
using MediatR;

namespace Catalog.Application.Queries
{
    public class GetSessionQuery : IRequest<SessionInfoModel>
    {
        public int Id { get; set; }

        public GetSessionQuery(int id)
        {
            this.Id = id;
        }
    }
}
