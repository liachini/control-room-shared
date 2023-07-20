using NCrontab;
using Newtonsoft.Json.Linq;

namespace SCM.SmartNotifications.Shared.Converters;

public class CrontabJsonConverter : JsonConverter<CrontabSchedule>
{
    /// <summary>Writes the JSON representation of the object.</summary>
    /// <param name="writer">The <see cref="T:Newtonsoft.Json.JsonWriter" /> to write to.</param>
    /// <param name="value">The value.</param>
    /// <param name="serializer">The calling serializer.</param>
    public override void WriteJson(JsonWriter writer, CrontabSchedule value, JsonSerializer serializer)
    {
        JToken t = JToken.FromObject(value.ToString());

        t.WriteTo(writer);
    }


    /// <summary>Reads the JSON representation of the object.</summary>
    /// <param name="reader">The <see cref="T:Newtonsoft.Json.JsonReader" /> to read from.</param>
    /// <param name="objectType">Type of the object.</param>
    /// <param name="existingValue">
    ///     The existing value of object being read. If there is no existing value then <c>null</c>
    ///     will be used.
    /// </param>
    /// <param name="hasExistingValue">The existing value has a value.</param>
    /// <param name="serializer">The calling serializer.</param>
    /// <returns>The object value.</returns>
    public override CrontabSchedule ReadJson(JsonReader reader, Type objectType, CrontabSchedule existingValue,
        bool hasExistingValue,
        JsonSerializer serializer)
    {
        object expression = reader.Value;
        return CrontabSchedule.Parse(expression.ToString());
    }
}