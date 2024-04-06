using ApplicationsService.Application.DTO;
using ApplicationsService.Infrastructure.EF.Models;

namespace ApplicationsService.Infrastructure.Queries;

internal static class Extensions
{
    public static ApplicationDto AsDto(this ApplicationReadModel readModel)
        => new()
        {
            Id = readModel.Id,
            UserId = readModel.UserId,
            Title = readModel.Title,
            Activity = readModel.Activity,
            Description = readModel.Description,
            Outline = readModel.Outline, 
        };
}