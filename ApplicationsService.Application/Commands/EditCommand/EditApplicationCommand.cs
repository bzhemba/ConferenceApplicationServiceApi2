using ApplicationsService.Abstractions.Commands;
using ApplicationsService.Domain.Consts;

namespace ApplicationsService.Application.Commands.EditCommand;

public record EditApplicationCommand(
    Guid id,
    Guid userId,
    string title,
    ActivityType activity,
    string? description,
    string outline) : ICommand;
