using ApplicationsService.Abstractions.Exceptions;

namespace ApplicationsService.Domain.Exceptions;

public class EmptyFieldsException: ApplicationsServiceException
{
    public EmptyFieldsException() :base("All application fields can't be empty. Input more information.")
    {
    }
}