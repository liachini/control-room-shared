namespace SCM.SmartNotifications.Shared.Entities;

public abstract record NotificationData: ITypeProvider
{
    public ScopeAggregationType AggregationType { get; set; }
    public ActionGroupSettings ActionGroup { get; set; }
    public abstract string _Type { get; }
}