using System.Dynamic;
using System.Globalization;
using Newtonsoft.Json.Linq;

namespace SCM.SmartNotifications.ApplicationCore.Shared.Extensions;

public static class ObjectExtension
{
    private const string scriptPlaceholder = "@";

    public static bool IsScript(this object value)
    {
        return value is string && Convert.ToString(value)!.StartsWith(scriptPlaceholder);
    }

    public static string AddScriptPlaceholder(this string expression)
    {
        return !expression.StartsWith(scriptPlaceholder) ? $"@{expression}" : expression;
    }

    public static string ToExpression(this object expression)
    {
        return Convert.ToString(expression, CultureInfo.InvariantCulture).RemoveStringFromBeginning(scriptPlaceholder);
    }

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
        if (o is string str) return str;

        return JsonConvert.SerializeObject(o);
    }

    public static string ToJson<TValue>(this Dictionary<string, TValue> o)
    {
        return o.ToJObject().ToString(Formatting.None);
    }


    public static dynamic ToDynamic(this object context)
    {
        if (context is not string json) json = context.ToJson();

        return JsonConvert.DeserializeObject<ExpandoObject>(json)!;
    }

    public static bool TryConvertToDynamic(object context, out dynamic res)
    {
        try
        {
            res = context.ToDynamic();
            return true;
        }
        catch (Exception e)
        {
            res = null;
            return false;
        }
    }

    public static JObject ToJObject<TValue>(this IDictionary<string, TValue> dictionary)
    {
        JObject root = new JObject();
        foreach (KeyValuePair<string, TValue> pair in dictionary)
        {
            string[] parts = pair.Key.Split('.');
            JObject current = root;
            for (int i = 0; i < parts.Length - 1; i++)
            {
                string part = parts[i];
                JObject next = current[part] as JObject;
                if (next == null)
                {
                    next = new JObject();
                    current[part] = next;
                }

                current = next;
            }

            current[parts.Last()] = JToken.FromObject(pair.Value);
        }

        return root;
    }
}