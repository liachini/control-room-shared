using SCM.SmartNotifications.ApplicationCore.Shared.Interfaces;

namespace SCM.SmartNotifications.ApplicationCore.Shared.Entities;

public sealed record RecipientsSettings : ITypeProvider
{
    public Dictionary<string, object> GroupFilters { get; set; }

    public List<User> Users { get; set; }

    public List<string> ExcludedUsers {get; set; }

    #region ITypeProvider

    public string _Type => nameof(RecipientsSettings);

    #endregion
}