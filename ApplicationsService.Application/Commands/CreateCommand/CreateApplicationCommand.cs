using ApplicationsService.Abstractions.Commands;
using ApplicationsService.Domain.Consts;

namespace ApplicationsService.Application.Commands.CreateCommand;

public record CreateApplicationCommand(
        Guid id,
        Guid userId,
        string title,
        ActivityType activity,
        string? description,
        string outline) : ICommand;