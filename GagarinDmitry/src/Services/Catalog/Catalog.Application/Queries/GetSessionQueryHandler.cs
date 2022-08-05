using AutoMapper;
using Catalog.Application.Models;
using Catalog.Domain.Entities;
using Catalog.Domain.Interfaces;
using MediatR;

namespace Catalog.Application.Queries
{
    public class GetSessionQueryHandler : IRequestHandler<GetSessionQuery, SessionInfoModel>
    {
        private readonly ISessionRepository sessionRepository;
        private readonly IMapper mapper;

        public GetSessionQueryHandler(ISessionRepository repository, IMapper mapper)
        {
            this.sessionRepository = repository;
            this.mapper = mapper;
        }

        public async Task<SessionInfoModel> Handle(GetSessionQuery request, CancellationToken cancellationToken)
        {
            var session = await sessionRepository.GetAsync(request.Id, cancellationToken);

            return mapper.Map<SessionInfoModel>(session);
        }
    }
}
