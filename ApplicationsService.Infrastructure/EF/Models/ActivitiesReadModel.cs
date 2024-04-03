using ApplicationsService.Domain.Consts;

namespace ApplicationsService.Infrastructure.EF.Models;

internal class ActivitiesReadModel
{
    public ActivityType Type { get; set; }
    public string Description { get; set; }
}