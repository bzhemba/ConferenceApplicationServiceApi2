using ApplicationsService.Domain.Repositories;
using ApplicationsService.Infrastructure.EF.Contexts;
using Microsoft.EntityFrameworkCore;
using ApplicationId = ApplicationsService.Domain.ValueObjects.ApplicationId;

namespace ApplicationsService.Infrastructure.EF.Repositories;

internal sealed class PostgresApplicationRepository : IApplicationsRepository
{
    private readonly DbSet<Domain.ValueObjects.Application> _applications;
    private readonly WriteDbContext _writeDbContext;

    public PostgresApplicationRepository(WriteDbContext writeDbContext)
    {
        _applications = writeDbContext.Applications;
        _writeDbContext = writeDbContext;
    }

    public Task<Domain.ValueObjects.Application> GetByIdAsync(ApplicationId id)
    =>
        _applications.SingleOrDefaultAsync(application => application.Id == id);
    public Task<Domain.ValueObjects.Application> GetDraftByUserIdAsync(Guid id)
        =>
            _applications.SingleOrDefaultAsync(application => (application.UserId == id) 
                                                              && (application.WasSent == false));

    public async Task AddAsync(Domain.ValueObjects.Application application)
    {
        await _applications.AddAsync(application);
        await _writeDbContext.SaveChangesAsync();
    }

    public async Task EditAsync(Domain.ValueObjects.Application application)
    {
        _applications.Update(application);
        await _writeDbContext.SaveChangesAsync();
    }

    public async Task ChangeStatusAsync(Domain.ValueObjects.Application application)
    {
        _applications.Update(application);
        await _writeDbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Domain.ValueObjects.Application application)
    {
         _applications.Remove(application);
        await _writeDbContext.SaveChangesAsync();
    }
}