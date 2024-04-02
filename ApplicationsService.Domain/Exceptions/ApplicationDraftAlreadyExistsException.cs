using ApplicationsService.Abstractions.Exceptions;

namespace ApplicationsService.Domain.Exceptions;

public class ApplicationDraftAlreadyExistsException : ApplicationsServiceException
{
    public Guid Id { get; }
    public ApplicationDraftAlreadyExistsException(Guid id) 
        : base($"Applications list already defined item '{id}'")
    {
        Id = id;
    }
}