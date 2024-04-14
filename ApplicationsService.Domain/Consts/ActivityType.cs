using System.ComponentModel;

namespace ApplicationsService.Domain.Consts;

public enum ActivityType
{
    [Description("Доклад, 35-45 минут")]
    Lecture,
    [Description("Мастеркласс, 1-2 часа")]
    Workshop,
    [Description("Дискуссия / круглый стол, 40-50 минут")]
    Discussion,
}