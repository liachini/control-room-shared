using FluentValidation;
using SCM.SmartNotifications.ApplicationCore.Shared.Entities;

namespace SCM.SmartNotifications.ApplicationCore.Shared.Validators;

internal class ScheduleValidator : AbstractValidator<Schedule>
{
    public ScheduleValidator()
    {
        RuleFor(schedule => schedule.Frequency).NotEmpty();
        RuleFor(schedule => schedule.CronSchedule).NotEmpty();
    }
}