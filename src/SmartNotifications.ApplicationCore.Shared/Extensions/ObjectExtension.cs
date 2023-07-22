using System.Dynamic;
using System.Globalization;

namespace SCM.SmartNotifications.ApplicationCore.Shared.Extensions;

public static class ObjectExtension
{
    public static bool IsNumeric(this object expression)
    {
        if (expression == null)
            return false;

        double number;
        return double.TryParse(Convert.ToString(expression
                , CultureInfo.InvariantCulture)
            , NumberStyles.Any
            , NumberFormatInfo.InvariantInfo
            , out number);
    }

    public static T Clone<T>(this T o)
    {
        return ToJson(o).FromJson<T>();
    }

    public static T FromJson<T>(this string serialized)
    {
        return JsonConvert.DeserializeObject<T>(serialized);
    }

    public static T FromJson<T>(this string serialized, Type asType)
    {
        return (T) JsonConvert.DeserializeObject(serialized, asType);
    }

    public static string ToJson<T>(this T o)
    {
        if (o is string str)
        {
            return str;
        }

        return JsonConvert.SerializeObject(o);
    }

    public static dynamic ToDynamic(this object context)
    {
        if (context is not string json)
        {
            json = context.ToJson();
        }

        return JsonConvert.DeserializeObject<ExpandoObject>(json)!;
    }
}

