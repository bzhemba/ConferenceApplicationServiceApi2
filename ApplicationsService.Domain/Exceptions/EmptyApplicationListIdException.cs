using ApplicationsService.Abstractions.Exceptions;

namespace ApplicationsService.Domain.Exceptions;

public class EmptyApplicationListIdException : ApplicationsServiceException
{
    public EmptyApplicationListIdException() :base("Application list Id can't be empty")
    {
    }
}