namespace SCM.SmartNotifications.ApplicationCore.Shared.Extensions;

public static class CommonExtensions
{
    public static bool IsNumber(this string value)
    {
        return double.TryParse(value, out _);
    }

    public static string RemoveStringFromBeginning(this string sourceString, string removeString)
    {
        int index = sourceString.IndexOf(removeString, StringComparison.Ordinal);
        return index < 0
            ? sourceString
            : sourceString.Remove(index, removeString.Length);
    }


    public static IDictionary<string, object> ToDictionary(this string value, char keyValueSeparator = '=',
        char itemSeparator = ';', char endValueSeparator = '-')
    {
        if (string.IsNullOrWhiteSpace(value)) return new Dictionary<string, object>();

        string input = value;
        if (value.IndexOf(endValueSeparator) >= 0 && value.IndexOf(endValueSeparator) <= value.Length)
            input = value[..value.IndexOf(endValueSeparator)];

        string[] strings = input.TrimEnd(itemSeparator).Split(itemSeparator);
        Dictionary<string, object> dictionary = strings
            .ToDictionary(item => item.Split(keyValueSeparator)[0], item => (object)item.Split(keyValueSeparator)[1]);

        return dictionary;
    }

    public static bool IsSupersetOf<TKey, TValue>(this IDictionary<TKey, TValue> source,
        IDictionary<TKey, TValue> other)
    {
        HashSet<KeyValuePair<TKey, TValue>> sourceHashSet = source.ToHashSet();
        HashSet<KeyValuePair<TKey, TValue>> otherHashSet = other.ToHashSet();

        return sourceHashSet.IsSupersetOf(otherHashSet);
    }
}