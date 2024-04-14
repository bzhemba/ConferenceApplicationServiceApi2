using ApplicationsService.Abstractions.Commands;

namespace ApplicationsService.Application.Commands.SendCommand;

public record SendApplicationCommand(Guid id) : ICommand;