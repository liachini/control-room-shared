using FluentAssertions;
using Microsoft.Extensions.Logging;
using NSubstitute;
using SCM.SmartNotifications.ApplicationCore.Shared.Entities;
using SCM.SmartNotifications.ApplicationCore.Shared.Interfaces;
using SCM.SmartNotifications.ApplicationCore.Shared.Services;

namespace UnitTests;

public class NotificationBuilderInstanceTests
{
    [Fact]
    public async Task Build_WithParameters_ReplacePlaceholderWithValues()
    {
        Dictionary<string, object> parameters = new Dictionary<string, object>
        {
            {"Name", "pippolo"},
            {"Threshold", 100}
        };
        NotificationTemplate template = new NotificationTemplate()
        {
            Notification = new Notification
            {
                Route = "@context.Parameters.Name",

                Data = new TriggerNotificationData()
            }
        };


        ScriptEngine scriptEngine = new ScriptEngine(Substitute.For<ILogger<ScriptEngine>>());

        INotificationInstanceBuilder builder =
            new NotificationBuilderInstance(
                new ExpressionEvaluator(scriptEngine));
        NotificationInstance notificationInstance = await builder.BuildAsync(template, parameters);

        notificationInstance.Parameters.Should().BeEquivalentTo(parameters);

        notificationInstance.Notification.Route.Should().Be("pippolo");
    }
}