namespace ApplicationsService.Application.Exceptions;

public class EmptyRequiredApplicationFieldsException: ApplicationException
{
    public Guid Id { get; }

    public EmptyRequiredApplicationFieldsException(Guid id) : base($"Application with ID '{id}'" +
                                                                   $" has required empty fields.")
        => Id = id;
}