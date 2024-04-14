namespace ApplicationsService.Application.Exceptions;

public class ApplicationNotFoundException : ApplicationException
{
    public Guid Id { get; }

    public ApplicationNotFoundException(Guid id) : base($"Application with ID '{id}' was not found.")
        => Id = id;
}