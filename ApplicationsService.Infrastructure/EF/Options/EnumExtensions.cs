using System.ComponentModel;
using ApplicationsService.Infrastructure.EF.Models;

namespace ApplicationsService.Infrastructure.EF.Options;

public class EnumExtensions
{
    
    public static List<EnumReadModel> GetValues<T>()
    {
        List<EnumReadModel> values = new List<EnumReadModel>();
        foreach (var itemType in Enum.GetValues(typeof(T)))
        {
            var enumType = itemType.GetType();
            var field = enumType.GetField(itemType.ToString());
            var attributes = field.GetCustomAttributes(typeof(DescriptionAttribute), false);
            var description = attributes.Length == 0
                ? itemType.ToString()
                : ((DescriptionAttribute)attributes[0]).Description;
            values.Add(new EnumReadModel()
            {
                Name = Enum.GetName(typeof(T), itemType), 
                Description = description
            });
        }
        return values;
    }
}