using ApplicationsService.Abstractions.Commands;
using ApplicationsService.Application.Commands.CreateCommand;
using ApplicationsService.Application.Exceptions;
using ApplicationsService.Domain.Factories;
using ApplicationsService.Domain.Repositories;

namespace ApplicationsService.Application.Commands.EditCommand;

internal sealed class EditApplicationCommandHandler : ICommandHandler<EditApplicationCommand>
{
    private readonly IApplicationsRepository _repository;
    private readonly IApplicationFactory _factory;

    public EditApplicationCommandHandler(IApplicationsRepository repository, IApplicationFactory factory)
    {
        _repository = repository;
        _factory = factory;
    }

    public async Task HandleAsync(EditApplicationCommand command)
    {
        var application = await _repository.GetByIdAsync(command.id);

        if (application is null)
        {
            throw new ApplicationNotFoundException(command.id);
        }
        if (application.WasSentStatus)
        {
            throw new EnableToEditOrDeleteApplicationException(command.id);
        }
        if (command.description != null) application.ChangeDescription(command.description);
        application.ChangeTitle(command.title);
        application.ChangeActivity(command.activity);
        application.ChangePlan(command.outline);
        await _repository.EditAsync(application);
    }
}