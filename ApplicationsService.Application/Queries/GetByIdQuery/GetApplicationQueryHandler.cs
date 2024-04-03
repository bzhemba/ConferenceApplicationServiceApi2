using ApplicationsService.Abstractions.Queries;
using ApplicationsService.Application.DTO;
using ApplicationsService.Domain.Repositories;

namespace ApplicationsService.Application.Queries.GetByIdQuery;

public class GetApplicationQueryHandler : IQueryHandler<GetApplicationQuery, ApplicationDto>
{
    private IApplicationsRepository _repository;

    public GetApplicationQueryHandler(IApplicationsRepository repository)
    {
        _repository = repository;
    }

    public Task<ApplicationDto> HandleAsync(GetApplicationQuery query)
    {
        var application = _repository.GetByIdAsync(query.Id);
        return application?.AsDto();
    }
}