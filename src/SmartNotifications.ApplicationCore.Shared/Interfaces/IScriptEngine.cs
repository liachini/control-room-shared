namespace SCM.SmartNotifications.ApplicationCore.Shared.Interfaces;

public interface IScriptEngine
{
    Task<T> EvaluateAsync<T>(string expression, object expandoObject, CancellationToken cancellationToken);
}