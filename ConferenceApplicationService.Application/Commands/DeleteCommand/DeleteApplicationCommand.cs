using ApplicationsService.Abstractions.Commands;

namespace ApplicationsService.Application.Commands.DeleteCommand;

public record DeleteApplicationCommand(Guid id) : ICommand;