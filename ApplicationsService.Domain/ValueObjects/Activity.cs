using ApplicationsService.Domain.Consts;

namespace ApplicationsService.Domain.ValueObjects;

public record Activity(ActivityType Type, string Description);
