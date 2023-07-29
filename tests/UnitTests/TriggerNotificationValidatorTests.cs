using System.Globalization;
using FluentValidation.TestHelper;
using SCM.SmartNotifications.ApplicationCore.Shared.Entities;
using SCM.SmartNotifications.ApplicationCore.Shared.Enums;
using SCM.SmartNotifications.ApplicationCore.Shared.Extensions;
using SCM.SmartNotifications.ApplicationCore.Shared.Validators;

namespace UnitTests;

public class TriggerNotificationValidatorTests
{
    [Fact]
    public async Task ValidateDirectNotification()
    {
        Notification notification = new Notification
        {
            Route = "TroubleShooting",
            Scope = new ScopeSettings
            {
                Source = ScopeSource.None,
            },
            Data = new TriggerNotificationData()
            {
                ActionGroup = new ActionGroupSettings
                {
                    Channels = new List<IChannel>
                    {
                        new PushChannel()
                        {
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
                        Users = new List<User>()
                        {
                            new User()
                            {
                                FirstName = "A",
                                LastName = "B",
                                Language = new CultureInfo("it"),
                                UserName = "UN",
                                Email = "email@nosense.com",
                                Id = "1"
                            }
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