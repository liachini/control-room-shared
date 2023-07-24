namespace SCM.SmartNotifications.Processor.ApplicationCore;

public static class SerializationExtensions
{
    public static string GetString(this ReadOnlyMemory<byte> readOnlyMemory)
    {
        return Encoding.UTF8.GetString(readOnlyMemory.ToArray());
    }
}