using ApplicationsService.Abstractions.Queries;
using ApplicationsService.Application.DTO;

namespace ApplicationsService.Application.Queries.GetByIdQuery;

public class GetApplicationQuery: IQuery<ApplicationDto>
{ 
    public Guid Id { get; set; }
}