using ApplicationsService.Abstractions.Queries;
using ApplicationsService.Application.DTO;

namespace ApplicationsService.Application.Queries.GetByDateQuery;

public class GetUnsubmittedApplicationsByDateQuery: IQuery<IEnumerable<ApplicationDto>>
{
    public DateTime Date { get; set; }
}