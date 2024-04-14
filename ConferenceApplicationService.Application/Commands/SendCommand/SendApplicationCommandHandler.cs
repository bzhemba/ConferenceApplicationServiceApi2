using ApplicationsService.Abstractions.Commands;
using ApplicationsService.Application.Commands.DeleteCommand;
using ApplicationsService.Application.Exceptions;
using ApplicationsService.Domain.Repositories;

namespace ApplicationsService.Application.Commands.SendCommand;

internal sealed class SendApplicationCommandHandler : ICommandHandler<SendApplicationCommand>
{
    private readonly IApplicationsRepository _repository;

    public SendApplicationCommandHandler(IApplicationsRepository repository)
        => _repository = repository;

    public async Task HandleAsync(SendApplicationCommand command)
    {
        var application = await _repository.GetByIdAsync(command.id);

        if (application is null)
        {
            throw new ApplicationNotFoundException(command.id);
        }

        var submitted_application = application;
        submitted_application.ChangeStatus();
        await _repository.ChangeStatusAsync(submitted_application);
    }
}