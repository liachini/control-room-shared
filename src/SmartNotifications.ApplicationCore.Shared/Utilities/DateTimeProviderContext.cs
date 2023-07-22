using System.Diagnostics;

namespace SCM.SmartNotifications.ApplicationCore.Shared.Utilities;

public class DateTimeProviderContext : IDisposable
{
    private static readonly ThreadLocal<Stack> ThreadScopeStack = new ThreadLocal<Stack>(() => new Stack());
    internal DateTime ContextDateTimeNow;

    public DateTimeProviderContext(DateTime contextDateTimeNow)
    {
        ContextDateTimeNow = contextDateTimeNow;
        ThreadScopeStack.Value!.Push(this);
    }

    public static DateTimeProviderContext Current
    {
        get
        {
            if (ThreadScopeStack.Value!.Count == 0)
                return null;
            return ThreadScopeStack.Value.Peek() as DateTimeProviderContext;
        }
    }

    public void Dispose()
    {
        object pop = ThreadScopeStack.Value!.Pop();
        Debug.WriteLine(pop);
    }
}