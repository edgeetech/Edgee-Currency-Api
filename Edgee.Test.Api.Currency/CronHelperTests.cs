using Edgee.Api.Currency.Utility;
using System;
using Xunit;

namespace Edgee.Test.Api.Currency
{
    public class CronHelperTests
    {
        [Fact]
        public void Test_CronHelper_FindNextUpdateTime_Returns()
        {
            // Arrange
            var baseDateTime = new DateTime(2020, 2, 18, 15, 50, 30);
            var expectedDateTime = new DateTime(2020, 2, 18, 16, 00, 00);
            var cronEveryWeekdayAt16 = "0 16 * * 1-5";
            // Run
            var result = CronHelper.FindNextUpdateTime(baseDateTime, cronEveryWeekdayAt16);

            // Assert
            Assert.Equal(result, expectedDateTime);
        }
    }
}
