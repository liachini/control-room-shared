using System.Globalization;

namespace SCM.SmartNotifications.Shared.Entities.Channels;

public sealed record LocalizedMessage : ITypeProvider
{
    public string _Type => nameof(LocalizedMessage);

    public Message DefaultMessage { get; set; }

    public Dictionary<CultureInfo, Message> Translations { get; set; }
}