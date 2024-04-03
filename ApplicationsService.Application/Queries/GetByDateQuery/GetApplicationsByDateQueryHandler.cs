using ApplicationsService.Abstractions.Queries;
using ApplicationsService.Application.DTO;

namespace ApplicationsService.Application.Queries.GetByDateQuery;

public class GetApplicationsByDateQueryHandler : IQueryHandler<GetApplicationsByDateQuery, IEnumerable<ApplicationDto>>
{
    private readonly ApplicationDbContext;
    public Task<IEnumerable<ApplicationDto>> HandleAsync(GetApplicationsByDateQuery query)
    {
    }