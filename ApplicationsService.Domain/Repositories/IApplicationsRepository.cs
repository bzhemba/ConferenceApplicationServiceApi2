using ApplicationsService.Domain.ValueObjects;
using ApplicationId = ApplicationsService.Domain.ValueObjects.ApplicationId;

namespace ApplicationsService.Domain.Repositories;

public interface IApplicationsRepository
{
    Task<Application> GetByIdAsync(ApplicationId id);
    Task AddAsync(Application application);
    Task EditAsync(Application application);
    Task ChangeStatusAsync(Application application);
    Task DeleteAsync(Application application);
}