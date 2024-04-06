using ApplicationsService.Domain.Consts;

namespace ApplicationsService.Application.DTO;

public class ApplicationDto
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string Title { get; set; }
    public string Activity { get; set; }
    public string? Description  { get; set; }
    public string Outline { get; set; }
    public DateTime DateTime { get; set; }
}