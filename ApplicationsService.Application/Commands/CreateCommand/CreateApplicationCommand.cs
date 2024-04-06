using ApplicationsService.Abstractions.Commands;
using ApplicationsService.Domain.Consts;

namespace ApplicationsService.Application.Commands.CreateCommand;

public record CreateApplicationCommand(
        Guid id,
        Guid userId,
        string title,
        string activity,
        string? description,
        string outline) : ICommand;