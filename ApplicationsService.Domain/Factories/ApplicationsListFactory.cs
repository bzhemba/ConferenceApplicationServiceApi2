using ApplicationsService.Domain.Entities;
using ApplicationsService.Domain.ValueObjects;
using ApplicationId = ApplicationsService.Domain.ValueObjects.ApplicationId;

namespace ApplicationsService.Domain.Factories;

public class ApplicationsListFactory : IApplicationsListFactory
{
    public ApplicationsList Create(ApplicationId id)
    {
        throw new NotImplementedException();
    }
}