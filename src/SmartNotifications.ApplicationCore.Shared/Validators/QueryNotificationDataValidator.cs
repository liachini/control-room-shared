using FluentValidation;

namespace SCM.SmartNotifications.ApplicationCore.Shared.Validators;

internal class QueryNotificationDataValidator : AbstractValidator<QueryNotificationData>
{
    public QueryNotificationDataValidator()
    {
        Include(new NotificationDataValidator());
    }
}