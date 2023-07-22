using System.Globalization;
using AutoFixture;
using FluentAssertions;
using NCrontab;
using Newtonsoft.Json;
using SCM.SmartNotifications.ApplicationCore.Shared.Entities;
using SCM.SmartNotifications.ApplicationCore.Shared.Enums;
using SCM.SmartNotifications.ApplicationCore.Shared.Extensions;

namespace UnitTests;

public class ModelBuilderTests
{

    [Fact]
    public void DeserializationModel()
    {
        TriggerNotificationData model = new TriggerNotificationData
        {
            Conditions = new List<IConditionSettings>()
            {
                new OperatorConditionSettings()
                {
                    Source = "A",
                    Operator = Operator.In

                }

            },
            ActionGroup = new ActionGroupSettings()
            {
                Channels = new List<IChannel>()
                {
                    new EmailChannel()
                }
            }

        };



        var result = model.ToJson().FromJson<TriggerNotificationData>();

        result.Should().NotBeNull();
        //result.Conditions.Should().NotBeNullOrEmpty();
    }

    [Fact]
    public void DeserializationDto()
    {
        Notification model = new Notification
        {
            Data = new TriggerNotificationData()
            {
                Conditions = new List<IConditionSettings>()
                {
                    new OperatorConditionSettings()
                },
                ActionGroup = new ActionGroupSettings()
                {
                    Channels = new List<IChannel>()
                    {
                        new EmailChannel()
                    }
                }

            }
        };

        var result = model.ToJson().FromJson<Notification>();
        result.Should().NotBeNull();
        TriggerNotificationData notificationData = (TriggerNotificationData)result.Data;
        notificationData.Conditions.Should().NotBeNullOrEmpty();
    }


    private Notification BuilTriggerNotification()
    {
        ActionGroupSettings actionGroup = new ActionGroupSettings
        {
            Recipients = new RecipientsSettings
            {
                GroupFilters = new Dictionary<string, object>
                {
                    {"BusinessCode", "@context.Scope"}
                }
            },
            Channels = new List<IChannel>
            {
                new EmailChannel
                {
                    LocalizedMessage = new LocalizedMessage
                    {
                        DefaultMessage = new Message("TITOLO", "BODY"),
                        Translations = new Dictionary<CultureInfo, Message>
                        {
                            {
                                new CultureInfo("it-IT"),
                                new Message("Titolo messaggio di @Firstname @Lastname",
                                    "Corpo messaggio @Firstname @Lastname")
                            },
                            {
                                new CultureInfo("en-EN"),
                                new Message("Title message of @Firstname @Lastname",
                                    "Body message @Firstname @Lastname")
                            }
                        }
                    }
                }
            }
        };

        Fixture fixture = new Fixture();
        OperatorConditionSettings operatorConditionSettings = fixture.Create<OperatorConditionSettings>();
        QueryConditionSettings queryConditionSettings = fixture.Create<QueryConditionSettings>();

        TriggerNotificationData reportNotificationData = new TriggerNotificationData
        {
            CheckSettings = new CheckSettings()
            {
                Count = 10,
                Duration = 300
            },
            Conditions = new List<IConditionSettings>()
            {
                operatorConditionSettings,
                queryConditionSettings
            },
            AggregationType = ScopeAggregationType.None,
            ActionGroup = actionGroup
        };


        ScopeSettings scopeSettings = new ScopeSettings
        {
            Parameters = new Dictionary<string, object>
            {
                {"Country", "ITA"},
                {"Type", "DEALER"}
            },
            Source = ScopeSource.OrgByCountry
        };

        Notification r = new Notification
        {
            Key = "ItemTest",

            Scope = scopeSettings,

            Data = reportNotificationData
        };

        return r;
    }


    private Notification BuildReportNotification()
    {
        ActionGroupSettings actionGroup = new ActionGroupSettings
        {
            Recipients = new RecipientsSettings
            {
                GroupFilters = new Dictionary<string, object>
                {
                    {"BusinessCode", "@context.Scope"}
                }
            },
            Channels = new List<IChannel>
            {
                new EmailChannel
                {
                    LocalizedMessage = new LocalizedMessage
                    {
                        DefaultMessage = new Message("TITOLO", "BODY"),
                        Translations = new Dictionary<CultureInfo, Message>
                        {
                            {
                                new CultureInfo("it-IT"),
                                new Message("Titolo messaggio di @Firstname @Lastname",
                                    "Corpo messaggio @Firstname @Lastname")
                            },
                            {
                                new CultureInfo("en-EN"),
                                new Message("Title message of @Firstname @Lastname",
                                    "Body message @Firstname @Lastname")
                            }
                        }
                    }
                }
            }
        };


        ReportNotificationData reportNotificationData = new ReportNotificationData
        {
            ApiUrl = new Url(new Uri("/mock/report"), HttpMethod.Get, new Dictionary<string, object>
            {
                {
                    "Frequency",
                    "@{if (context.NotificationData.Schedule.Name == \"Weekly\"){return \"weekly\";} return \"default\";}"
                }
            }),
            SelectedSchedule = new Schedule
            {
                Frequency = "Weekly",
                CronSchedule = CrontabSchedule.Parse("0 5 * * *")
            },
            AggregationType = ScopeAggregationType.None,
            ActionGroup = actionGroup
        };


        ScopeSettings scopeSettings = new ScopeSettings
        {
            Parameters = new Dictionary<string, object>
            {
                {"Country", "ITA"},
                {"Type", "DEALER"}
            },
            Source = ScopeSource.OrgByCountry
        };

        Notification r = new Notification
        {
            Key = "MachineAvailabiltyByOrganization",

            Scope = scopeSettings,

            Data = reportNotificationData
        };

        return r;
    }

    [Fact]
    public async Task TestReportNotificationData()
    {
        ActionGroupSettings actionGroup = new ActionGroupSettings
        {
            Recipients = new RecipientsSettings
            {
                GroupFilters = new Dictionary<string, object>
                {
                    {"BusinessCode", "@context.Scope"}
                }
            },
            Channels = new List<IChannel>
            {
                new EmailChannel
                {
                    LocalizedMessage = new LocalizedMessage
                    {
                        DefaultMessage = new Message("TITOLO", "BODY"),
                        Translations = new Dictionary<CultureInfo, Message>
                        {
                            {
                                new CultureInfo("it-IT"),
                                new Message("Titolo messaggio di @Firstname @Lastname",
                                    "Corpo messaggio @Firstname @Lastname")
                            },
                            {
                                new CultureInfo("en-EN"),
                                new Message("Title message of @Firstname @Lastname",
                                    "Body message @Firstname @Lastname")
                            }
                        }
                    }
                }
            }
        };


        ReportNotificationData reportNotificationData = new ReportNotificationData
        {
            ApiUrl = new Url(new Uri("/mock/report", UriKind.Relative), HttpMethod.Get, new Dictionary<string, object>
            {
                {
                    "Frequency",
                    "@{if (context.NotificationData.Schedule.Name == \"Weekly\"){return \"weekly\";} return \"default\";}"
                }
            }),
            SelectedSchedule = new Schedule { Frequency = "Weekly", CronSchedule = CrontabSchedule.Parse("0 5 * * *") },
            AggregationType = ScopeAggregationType.None,
            ActionGroup = actionGroup
        };


        ScopeSettings scopeSettings = new ScopeSettings
        {
            Parameters = new Dictionary<string, object>
            {
                {
                    "Country",
                    "ITA"
                },
                {
                    "Type",
                    "DEALER"
                }
            },
            Source = ScopeSource.OrgByCountry
        };

        Notification r = new Notification
        {
            Scope = scopeSettings,
            Key = "MachineAvailabiltyByOrganization",

            Data = reportNotificationData
        };


        string res = JsonConvert.SerializeObject(r);


        try
        {
            /*EmailChannel emailChannel = new EmailChannel();
            var l = new List<Channel>();
            l.Add(emailChannel);

            string emailSerialized = JsonConvert.SerializeObject(l);
            EmailChannelModel emailChannelModel = await modelBuilder.Build<Channel, EmailChannelModel>(emailSerialized);

            ReportNotificationModel reportNotificationModel = await modelBuilder.Build<Notification,ReportNotificationModel>(res);*/
        }
        catch (Exception e)
        {
        }
    }



}