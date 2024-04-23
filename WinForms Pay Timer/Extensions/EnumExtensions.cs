using System.Text.RegularExpressions;

namespace RealTime_Revenue.Extensions;
public static class EnumExtensions
{
    public static string ToSentenceCase(this Enum enumValue)
    {
        string name = enumValue.ToString();
        return Regex.Replace(name, "(?<=[a-z])([A-Z])", " $1");
    }
}
