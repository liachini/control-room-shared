using FluentValidation;

namespace SCM.SmartNotifications.ApplicationCore.Shared.Validators;

internal class ScheduleValidator : AbstractValidator<Schedule>
{
    public ScheduleValidator()
    {
        RuleFor(schedule => schedule.Frequency).NotEmpty();
        RuleFor(schedule => schedule.CronSchedule).NotEmpty();
    }
}