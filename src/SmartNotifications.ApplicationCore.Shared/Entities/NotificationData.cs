using SCM.SmartNotifications.ApplicationCore.Shared.Enums;
using SCM.SmartNotifications.ApplicationCore.Shared.Interfaces;

namespace SCM.SmartNotifications.ApplicationCore.Shared.Entities;

public abstract record NotificationData : ITypeProvider
{
    public ScopeAggregationType AggregationType { get; set; }
    public ActionGroupSettings ActionGroup { get; set; }
    public abstract string _Type { get; }
}