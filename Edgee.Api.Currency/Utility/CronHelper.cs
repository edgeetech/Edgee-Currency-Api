using NCrontab;
using System;

namespace Edgee.Api.Currency.Utility
{
    public class CronHelper
    {
        public static DateTime FindNextUpdateTime(DateTime baseTime, string cronExpression)
        {
            var schedule = CrontabSchedule.Parse(cronExpression);
            return schedule.GetNextOccurrence(baseTime);
        }
    }
}
