namespace ApplicationsService.Abstractions.Exceptions;

public abstract class ApplicationsServiceException : Exception
{
    protected ApplicationsServiceException(string message) : base(message)
    {
        
    }
}