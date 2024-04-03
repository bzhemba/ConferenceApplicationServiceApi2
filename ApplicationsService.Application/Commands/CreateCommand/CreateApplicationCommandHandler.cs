using ApplicationsService.Abstractions.Commands;
using ApplicationsService.Domain.Factories;
using ApplicationsService.Domain.Repositories;

namespace ApplicationsService.Application.Commands.CreateCommand;

internal sealed class CreateApplicationCommandHandler : ICommandHandler<CreateApplicationCommand>
{
    private readonly IApplicationsRepository _repository;
    private readonly IApplicationFactory _factory;

    public CreateApplicationCommandHandler(IApplicationsRepository repository, IApplicationFactory factory)
    {
        _repository = repository;
        _factory = factory;
    }

    public async Task HandleAsync(CreateApplicationCommand command)
    {
        var (id, userId, title, activity, description, outline) = command;

        var application = _factory.Create(id, userId, activity, title, description, outline);
        await _repository.AddAsync(application);
    }
}