using System.Dynamic;
using System.Globalization;
using Newtonsoft.Json.Linq;

namespace SCM.SmartNotifications.ApplicationCore.Shared.Extensions;

public static class ObjectExtension
{
    public static bool IsScript(this object value)
    {
        return value is string && Convert.ToString(value)!.StartsWith("@");
    }

    public static string AddScriptPlaceholder(this string expression)
    {
        return !expression.StartsWith("@") ? $"@{expression}" : expression;
    }
    public static string ToExpression(this object expression)
    {
        return Convert.ToString(expression, CultureInfo.InvariantCulture).RemoveStringFromBeginning("@");
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

    public static string ToJson<TValue>(this Dictionary<string,TValue> o)
    {

        return o.ToJObject().ToString(Formatting.None);
    }



    public static dynamic ToDynamic(this object context)
    {
        if (context is not string json) json = context.ToJson();

        return JsonConvert.DeserializeObject<ExpandoObject>(json)!;
    }
}

public static class DictionaryExtensions
{
    public static JObject ToJObject<TValue>(this IDictionary<string, TValue> dictionary)
    {
        var root = new JObject();
        foreach (var pair in dictionary)
        {
            var parts = pair.Key.Split('.');
            var current = root;
            for (int i = 0; i < parts.Length - 1; i++)
            {
                var part = parts[i];
                var next = current[part] as JObject;
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
