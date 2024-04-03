using ApplicationsService.Abstractions.Exceptions;

namespace ApplicationsService.Domain.Exceptions;

public class EmptyApplicationIdException : ApplicationsServiceException
{
    public EmptyApplicationIdException() :base("Application list Id can't be empty")
    {
    }
}