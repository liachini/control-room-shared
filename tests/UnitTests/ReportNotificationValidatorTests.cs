using System.Globalization;
using FluentValidation.TestHelper;
using NCrontab;
using SCM.SmartNotifications.ApplicationCore.Shared.Entities;
using SCM.SmartNotifications.ApplicationCore.Shared.Enums;
using SCM.SmartNotifications.ApplicationCore.Shared.Extensions;
using SCM.SmartNotifications.ApplicationCore.Shared.Validators;

namespace UnitTests;

public class ReportNotificationValidatorTests
{
    [Fact]
    public async Task ValidateNotification()
    {
        Notification notification = new Notification
        {
            Route = "MachineAvailabiltyByOrganization",
            Scope = new ScopeSettings
            {
                Source = ScopeSource.OrgByCountry,
                Parameters = new Dictionary<string, object>
                {
                    { "Country", "XXX" },
                    { "Type", "CUSTOMER" }
                }
            },
            Data = new ReportNotificationData
            {
                SelectedSchedule = new Schedule
                {
                    Frequency = "Weekly",
                    CronSchedule = CrontabSchedule.Parse("* */5 * * *")
                },
                ApiUrl = new Url(new Uri("/main-ui/{organization}/machinesavailabilityreport", UriKind.Relative), HttpMethod.Get,
                    new Dictionary<string, object>
                    {
                        { "organization", "@Context.CurrentScope" }
                    }),

                ActionGroup = new ActionGroupSettings
                {
                    Channels = new List<IChannel>
                    {
                        new EmailChannel
                        {
                            TemplateName = "orgbycountry",
                            LocalizedMessage = new LocalizedMessage
                            {
                                DefaultMessage = new Message(
                                    "Machine Status  Report of {{User.FirstName}} {{User.LastName}} DEFAULT",
                                    "<p>Dear {{User.FirstName}} {{User.LastName}},</p><p>Attached you can find the periodic report of the status of your machines.</p><p>Sincerely, SCM Group</p><p><a style=\"text-decoration: none; border-bottom: 1px solid #5e5e5e;\" href=\"{{unsubscribeUrl}}\" target=\"_blank\"><strong style=\"font-weight: normal; color: #5e5e5e;\">Cancel your subscription</strong></a></p>DEFAULT"),
                                Translations = new Dictionary<CultureInfo, Message>
                                {
                                    {
                                        new CultureInfo("it-IT"),
                                        new Message("Report Stato Macchine di {{User.FirstName}} - {{User.LastName}}",
                                            "<p>Caro  {{User.FirstName}} {{User.LastName}},</p><p>in allegato pu&ograve; trovare il report periodico dello stato delle sue macchine.</p><p>Cordialmente, SCM Group</p><p><a style=\"text-decoration: none; border-bottom: 1px solid #5e5e5e;\" href=\"{{unsubscribeUrl}}\" target=\"_blank\"><strong style=\"font-weight: normal; color: #5e5e5e;\">Annulla la sottoscrizione</strong></a></p>")
                                    },
                                    {
                                        new CultureInfo("en-EN"),
                                        new Message("Machine Status Report  nof {{User.FirstName}} {{User.LastName}}",
                                            "<p>Dear  {{User.FirstName}} {{User.LastName}},</p><p>Attached you can find the periodic report of the status of your machines.</p><p>Sincerely, SCM Group</p><p><a style=\"text-decoration: none; border-bottom: 1px solid #5e5e5e;\" href=\"{{unsubscribeUrl}}\" target=\"_blank\"><strong style=\"font-weight: normal; color: #5e5e5e;\">Cancel your subscription</strong></a></p>")
                                    },
                                    {
                                        new CultureInfo("da-DK"),
                                        new Message("Maskin status rapport  fra {{User.FirstName}} {{User.LastName}}",
                                            "<p>Kære {{User.FirstName}} {{User.LastName}},</p><p>Vedlagt kan du finde den periodiske rapport over status for dine maskiner.</p><p>Med venlig hilsen, SCM Group</p><p>Cordialmente, SCM Group</p><p><a style=\"text-decoration: none; border-bottom: 1px solid #5e5e5e;\" href=\"{{unsubscribeUrl}}\" target=\"_blank\"><strong style=\"font-weight: normal; color: #5e5e5e;\">Opsig dit abonnement</strong></a></p>")
                                    }
                                }
                            }
                        }
                    },
                    Recipients = new RecipientsSettings
                    {
                        GroupFilters = new Dictionary<string, object>
                        {
                            { "BusinessCode", "@context.CurrentScope" }
                        }
                    }
                }
            }
        };

        string json = notification.ToJson();

        NotificationValidator validator = new NotificationValidator();
        TestValidationResult<Notification> validationResult = await validator.TestValidateAsync(notification);


        validationResult.ShouldNotHaveAnyValidationErrors();
    }
}