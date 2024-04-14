namespace ApplicationsService.Application.Exceptions;

public class EnableToEditOrDeleteApplicationException : ApplicationException
{
    public Guid Id { get; }
    public EnableToEditOrDeleteApplicationException(Guid id) :
        base($"You can't delete OR edit submitted application '{id}'") =>
        Id = id;
}