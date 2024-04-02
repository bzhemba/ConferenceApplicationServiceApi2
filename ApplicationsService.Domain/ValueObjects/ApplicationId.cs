using ApplicationsService.Domain.Exceptions;

namespace ApplicationsService.Domain.ValueObjects;

public record ApplicationId
{
    public Guid Value { get; }

    public ApplicationId(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new EmptyApplicationListIdException();
        }
            
        Value = value;
    }
        
    public static implicit operator Guid(ApplicationId id)
        => id.Value;
        
    public static implicit operator ApplicationId(Guid id)
        => new(id);
}