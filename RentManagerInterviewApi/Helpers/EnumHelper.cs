using System.ComponentModel;
using System.Reflection;

namespace RentManagerInterviewApi.Helpers
{
    public static class EnumHelper
    {
        public static string GetDescription(Enum value)
        {
            return value.GetType()
                        .GetMember(value.ToString())
                        .FirstOrDefault()
                        ?.GetCustomAttribute<DescriptionAttribute>()
                        ?.Description ?? value.ToString();
        }
    }
}
