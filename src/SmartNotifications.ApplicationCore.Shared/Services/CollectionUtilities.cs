using System.Collections;
using System.Globalization;

namespace SCM.SmartNotifications.ApplicationCore.Shared.Services;

public static class CollectionUtilities
{
    public static bool Contains(object source, object value)
    {
        if (source == null || value == null) return false;

        return ConvertToStringList(source).Contains(Convert.ToString(value, CultureInfo.InvariantCulture));
    }

    private static List<string> ConvertToStringList(object values)
    {
        if (values is IList list) return (from object t in list select t.ToString()).ToList();

        string vals = Convert.ToString(values)!;
        return vals.Split(',').ToList();
    }
}