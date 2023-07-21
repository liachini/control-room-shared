using JsonSubTypes;

namespace SCM.SmartNotifications.ApplicationCore.Shared.Interfaces;



[JsonConverter(typeof(JsonSubtypes), nameof(_Type))]
public interface ITypeProvider
{
    public string _Type { get; }
}