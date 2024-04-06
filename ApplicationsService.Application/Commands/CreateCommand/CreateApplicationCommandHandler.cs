using ApplicationsService.Abstractions.Commands;
using ApplicationsService.Domain.Consts;
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
        ActivityType activity_formatted = (ActivityType)Enum.Parse(typeof(ActivityType), activity);
        var application = _factory.Create(id, userId, activity_formatted, title, description, outline);
        await _repository.AddAsync(application);
    }
}