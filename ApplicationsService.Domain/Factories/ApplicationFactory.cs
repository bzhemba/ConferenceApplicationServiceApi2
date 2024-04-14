using ApplicationsService.Domain.Consts;
using ApplicationsService.Domain.Exceptions;
using ApplicationsService.Domain.ValueObjects;
using ApplicationId = ApplicationsService.Domain.ValueObjects.ApplicationId;

namespace ApplicationsService.Domain.Factories;

public class ApplicationFactory : IApplicationFactory
{
    public Application Create(ApplicationId id, Guid userId, ActivityType activity, string? title, string? description,
        string? outline)
    {
        if (userId == null)
        {
            throw new EmptyUserIdException();
        }

        if (activity != null || title != null || description != null || outline != null)
        {
            return new Application(id, userId, activity, title, description, outline);
        }

        throw new EmptyFieldsException();
    }
}