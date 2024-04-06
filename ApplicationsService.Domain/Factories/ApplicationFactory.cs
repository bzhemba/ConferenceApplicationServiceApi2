using ApplicationsService.Domain.Consts;
using ApplicationsService.Domain.ValueObjects;
using ApplicationId = ApplicationsService.Domain.ValueObjects.ApplicationId;

namespace ApplicationsService.Domain.Factories;

public class ApplicationFactory : IApplicationFactory
{
    public Application Create(ApplicationId id, Guid userId, ActivityType activity, string title, string? description, string outline)
    {
        return new Application(id, userId, activity, title, description, outline);
    }
}