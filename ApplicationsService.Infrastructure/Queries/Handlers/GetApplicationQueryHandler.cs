using ApplicationsService.Abstractions.Queries;
using ApplicationsService.Application.DTO;
using ApplicationsService.Application.Queries.GetByIdQuery;
using ApplicationsService.Domain.Repositories;
using ApplicationsService.Infrastructure.EF.Models;

namespace ApplicationsService.Infrastructure.Queries.Handlers;

public class GetApplicationQueryHandler : IQueryHandler<GetApplicationQuery, ApplicationReadModel>
{
    private IApplicationsRepository _repository;

    public GetApplicationQueryHandler(IApplicationsRepository repository)
    {
        _repository = repository;
    }

    public Task<ApplicationReadModel> HandleAsync(GetApplicationQuery query)
    {
        var application = _repository.GetByIdAsync(query.Id);
        return application?.AsDto();
    }
}