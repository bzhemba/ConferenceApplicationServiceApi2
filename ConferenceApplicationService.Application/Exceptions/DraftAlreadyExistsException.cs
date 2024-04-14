namespace ApplicationsService.Application.Exceptions;

public class DraftAlreadyExistsException: ApplicationException
{
    public Guid Id { get; }

    public DraftAlreadyExistsException(Guid id) : base($"You already have draft application with ID '{id}'.")
        => Id = id;
}