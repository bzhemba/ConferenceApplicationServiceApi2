using ApplicationsService.Domain.Consts;

namespace ApplicationsService.Infrastructure.EF.Models;

internal class ApplicationReadModel
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string Title { get; set; }
    public string Activity { get; set; }
    public string? Description  { get; set; }
    public string Outline { get; set; }
    public DateTime Date { get; set; }
    public bool WasSent { get; set; }
}