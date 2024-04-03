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
        var application = await _repository.GetByIdAsync(command.Id);

        if (application is null)
        {
            throw new ApplicationNotFoundException(command.Id);
        }
        if (application.WasSentStatus)
        {
            throw new EnableToEditOrDeleteApplicationException(command.Id);
        }

        await _repository.DeleteAsync(application);
    }
}