using ApplicationsService.Application.DTO;

namespace ApplicationsService.Application.Services;

public interface IApplicationReadService
{
    Task<IEnumerable<ApplicationDto>> GetByDateAsync(DateTime date);
}