using AutoFixture;
using FluentAssertions;
using SCM.SmartNotifications.ApplicationCore.Shared.Entities;
using SCM.SmartNotifications.ApplicationCore.Shared.Extensions;

namespace UnitTests;

public class NotificationTemplateTests
{
    [Fact]
    public void Serialize_NotificationTemplate()
    {
        Fixture fixture = new Fixture();

        NotificationTemplate expected = new NotificationTemplate();
        expected.Notification = new Notification
        {
            Data = new TriggerNotificationData
            {
                CheckSettings = fixture.Create<CheckSettings>(),
                ActionGroup = new ActionGroupSettings
                {
                    Recipients = fixture.Create<RecipientsSettings>(),
                    Channels = new List<IChannel>
                    {
                        new EmailChannel(),
                        new MobileChannel(),
                        new PushChannel(),
                        new WebhookChannel()
                    }
                },
                Conditions = new List<IConditionSettings>
                {
                    new OperatorConditionSettings(),
                    new QueryConditionSettings()
                }
            }
        };

        string json = expected.ToJson();

        NotificationTemplate actual = json.FromJson<NotificationTemplate>();

        actual.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void Serialize_IChannel()
    {
        Fixture fixture = new Fixture();

        List<IChannel> expected = new List<IChannel>();
        expected.Add(new EmailChannel());

        List<IChannel> actual = expected.ToJson().FromJson<List<IChannel>>();

        actual.Should().BeEquivalentTo(expected);
    }
}