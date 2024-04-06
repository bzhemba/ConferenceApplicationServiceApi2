using ApplicationsService.Domain.Consts;
using ApplicationsService.Domain.ValueObjects;
using ApplicationId = ApplicationsService.Domain.ValueObjects.ApplicationId;

namespace ApplicationsService.Domain.Factories;

public interface IApplicationFactory
{
    Application Create(ApplicationId id, Guid userId, ActivityType activity, string title, string? description, string outline);
}