using ApplicationsService.Abstractions.Queries;
using ApplicationsService.Application.DTO;
using ApplicationsService.Application.Queries.GetByDateQuery;
using ApplicationsService.Infrastructure.EF.Models;

namespace ApplicationsService.Infrastructure.Queries.Handlers;

public class GetApplicationsByDateQueryHandler : IQueryHandler<GetApplicationsByDateQuery, IEnumerable<ApplicationReadModel>>
{
    private readonly ApplicationDbContext;
    public Task<IEnumerable<ApplicationReadModel>> HandleAsync(GetApplicationsByDateQuery query)
    {
    }