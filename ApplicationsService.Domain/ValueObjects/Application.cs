using ApplicationsService.Domain.Consts;

namespace ApplicationsService.Domain.ValueObjects;

public class Application
{
    public Application(Guid id, Guid userId, ActivityType activity, string title, string? description, string outline)
    {
        Id = id;
        UserId = userId;
        Activity = activity;
        Title = title;
        Description = description;
        Outline = outline;
        WasSentStatus = false;
        Date = DateTime.Now;
    }

    public Guid Id { get; }
    public Guid UserId { get; }
    public ActivityType Activity { get; private set; }
    public string Title { get; private set; }
    public string? Description { get; private set; }
    public string Outline { get; private set; }
    public bool WasSentStatus { get; private set; }
    public DateTime Date { get; }
    public void ChangeDescription(string newDescription)
    {
        Description = newDescription;
    }
    public void ChangeTitle(string newTitle)
    {
        Title = newTitle;
    }
    public void ChangePlan(string newPlan)
    {
        Outline = newPlan;
    }

    public void ChangeActivity(ActivityType newActivity)
    {
        Activity = newActivity;
    }

    public void ChangeStatus()
    {
        WasSentStatus = true;
    }
}