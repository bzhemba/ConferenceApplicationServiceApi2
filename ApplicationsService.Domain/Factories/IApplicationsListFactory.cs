using ApplicationsService.Domain.Entities;
using ApplicationsService.Domain.ValueObjects;
using ApplicationId = ApplicationsService.Domain.ValueObjects.ApplicationId;

namespace ApplicationsService.Domain.Factories;

public interface IApplicationsListFactory
{
    ApplicationsList Create(ApplicationId id);
}