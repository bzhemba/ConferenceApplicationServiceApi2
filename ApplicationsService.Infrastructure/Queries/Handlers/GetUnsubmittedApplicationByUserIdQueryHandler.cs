using ApplicationsService.Abstractions.Queries;
using ApplicationsService.Application.DTO;
using ApplicationsService.Application.Queries.GetByIdQuery;
using ApplicationsService.Infrastructure.EF.Contexts;
using ApplicationsService.Infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;

namespace ApplicationsService.Infrastructure.Queries.Handlers;

internal sealed class GetUnsubmittedApplicationByUserIdQueryHandler: IQueryHandler<GetApplicationByUserIdQuery, ApplicationDto>
{
    private readonly DbSet<ApplicationReadModel> _applications;

    public GetUnsubmittedApplicationByUserIdQueryHandler(ReadDbContext context)
    {
        _applications = context.Applications;
    }

    public Task<ApplicationDto> HandleAsync(GetApplicationByUserIdQuery query)
        => _applications
            .Where(application => (application.UserId == query.UserId) && (application.WasSent == false))
            .Select(application => application.AsDto())
            .AsNoTracking()
            .SingleOrDefaultAsync();
}