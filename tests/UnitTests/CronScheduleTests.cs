using FluentAssertions;
using NCrontab;
using Newtonsoft.Json;
using SCM.SmartNotifications.ApplicationCore.Shared.Entities;

namespace UnitTests;

public class CronScheduleTests
{

    [Fact]
    public void GetValueFromJson()
    {
        string json = @"{
                            'MachineId': 'abc',
                            'Value': 50
                        }";

        Dictionary<string, object> values = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
    }

    [Fact]
    public void ScheduleModelWithSameCrontab_ShouldBeEquals()
    {
        Schedule s1 = new Schedule
        {
            CronSchedule = CrontabSchedule.Parse("* * * * *")
        };

        Schedule s2 = new Schedule
        {
            CronSchedule = CrontabSchedule.Parse("* * * * *")
        };


        s1.Should().BeEquivalentTo(s2);
    }

    [Fact]
    public void ScheduleModelWithDifferentCrontab_ShouldNotBeEquals()
    {
        Schedule s1 = new Schedule
        {
            CronSchedule = CrontabSchedule.Parse("0 1 * * *")
        };

        Schedule s2 = new Schedule
        {
            CronSchedule = CrontabSchedule.Parse("* * * * *")
        };


        s1.Should().NotBe(s2);
    }

}