using ApplicationsService.Abstractions.Commands;
using ApplicationsService.Application.Exceptions;
using ApplicationsService.Domain.Repositories;

namespace ApplicationsService.Application.Commands.DeleteCommand;

internal sealed class DeleteApplicationCommandHandler : ICommandHandler<DeleteApplicationCommand>
{
    private readonly IApplicationsRepository _repository;

    public DeleteApplicationCommandHandler(IApplicationsRepository repository)
        => _repository = repository;

    public async Task HandleAsync(DeleteApplicationCommand command)
    {
        var application = await _repository.GetByIdAsync(command.id);

        if (application is null)
        {
            throw new ApplicationNotFoundException(command.id);
        }
        if (application.WasSent)
        {
            throw new EnableToEditOrDeleteApplicationException(command.id);
        }

        await _repository.DeleteAsync(application);
    }
}