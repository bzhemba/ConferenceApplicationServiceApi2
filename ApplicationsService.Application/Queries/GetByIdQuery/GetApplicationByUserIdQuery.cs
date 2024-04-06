using ApplicationsService.Abstractions.Queries;
using ApplicationsService.Application.DTO;

namespace ApplicationsService.Application.Queries.GetByIdQuery;

public class GetApplicationByUserIdQuery : IQuery<ApplicationDto>
{
    public Guid UserId { get; set; }
}