using ApplicationsService.Abstractions.Exceptions;

namespace ApplicationsService.Domain.Exceptions;

public class ApplicationNotFoundException : ApplicationsServiceException
{
    public Guid ApplicationId{ get; }

    public ApplicationNotFoundException(Guid id) : base($"Application '{id}' was not found.")
        => ApplicationId = id;
}