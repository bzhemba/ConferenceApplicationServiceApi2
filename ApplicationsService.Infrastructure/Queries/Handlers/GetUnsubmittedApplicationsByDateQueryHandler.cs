using ApplicationsService.Abstractions.Queries;
using ApplicationsService.Application.DTO;
using ApplicationsService.Application.Queries.GetByDateQuery;
using ApplicationsService.Infrastructure.EF.Contexts;
using ApplicationsService.Infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;

namespace ApplicationsService.Infrastructure.Queries.Handlers;

internal sealed class
    GetUnsubmittedApplicationsByDateQueryHandler : IQueryHandler<GetUnsubmittedApplicationsByDateQuery, IEnumerable<ApplicationDto>>
{
    private readonly DbSet<ApplicationReadModel> _applications;

    public GetUnsubmittedApplicationsByDateQueryHandler(ReadDbContext context)
    {
        _applications = context.Applications;
    }

    public async Task<IEnumerable<ApplicationDto>> HandleAsync(GetUnsubmittedApplicationsByDateQuery query)
    {
        var dbQuery = _applications.AsQueryable();
        dbQuery = dbQuery.Where(application => (application.WasSent == false) && (application.Date < query.Date));
        return await dbQuery.Select(application => application.AsDto()).AsNoTracking().ToListAsync();
    }
}