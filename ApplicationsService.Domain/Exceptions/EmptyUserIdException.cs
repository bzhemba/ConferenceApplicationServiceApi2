using ApplicationsService.Abstractions.Exceptions;

namespace ApplicationsService.Domain.Exceptions;

public class EmptyUserIdException: ApplicationsServiceException
{
    public EmptyUserIdException() :base("User id can't be empty")
    {
    }
}