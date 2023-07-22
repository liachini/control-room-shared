namespace SCM.SmartNotifications.ApplicationCore.Shared.Services;

public interface IScriptEngine
{
    Task<T> EvaluateAsync<T>(string expression, object expandoObject, CancellationToken cancellationToken);
}