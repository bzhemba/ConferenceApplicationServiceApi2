using ApplicationsService.Abstractions.Queries;
using ApplicationsService.Application.DTO;
using ApplicationsService.Application.Queries.GetByIdQuery;
using ApplicationsService.Domain.Repositories;
using ApplicationsService.Infrastructure.EF.Contexts;
using ApplicationsService.Infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;

namespace ApplicationsService.Infrastructure.Queries.Handlers;

internal sealed class GetApplicationQueryHandler : IQueryHandler<GetApplicationQuery, ApplicationDto>
{
    private readonly DbSet<ApplicationReadModel> _applications;

    public GetApplicationQueryHandler(ReadDbContext context)
    {
        _applications = context.Applications;
    }

    public Task<ApplicationDto> HandleAsync(GetApplicationQuery query)
        => _applications
            .Where(application => application.Id == query.Id)
            .Select(application => application.AsDto())
            .AsNoTracking()
            .SingleOrDefaultAsync();
}