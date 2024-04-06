using ApplicationsService.Abstractions.Exceptions;

namespace ApplicationsService.Domain.Exceptions;

public class EmptyApplicationIdException : ApplicationsServiceException
{
    public EmptyApplicationIdException() :base("Application id can't be empty")
    {
    }
}