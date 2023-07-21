using FluentValidation;
using SCM.SmartNotifications.Shared.Entities;

namespace SCM.SmartNotifications.Shared.Validators;

internal class ScheduleValidator : AbstractValidator<Schedule>
{
    public ScheduleValidator()
    {
        RuleFor(schedule => schedule.Frequency).NotEmpty();
        RuleFor(schedule => schedule.CronSchedule).NotEmpty();
    }
}