
using BlzAppAzurePl.Client.Util;

namespace BlzAppAzurePl.Client.Test
{
    public class DriverTest
    {
        private readonly IDrivable driver;

        public DriverTest()
        {
            driver = new Driver();
        }

        [Theory]
        [InlineData(30, 30, "legal")]
        [InlineData(100, 110, "legal")]
        public void When_Valid_Speed_Should_Return_Ok_TextContent(int actual, int maxSpeed, string expected)
        {
            //Arrange
            Func<int, int, bool> speedChecker = (actSpeed, expSpeed) => { return actSpeed <= expSpeed; };

            //Act
            var result = driver.Drive(speedChecker, actual, maxSpeed).ToLower();

            //Assert
            Assert.Contains(expected, result);


        }

        [Theory]
        [InlineData(50, 30, "cracked")]
        [InlineData(120, 110, "cracked")]
        public void When_speedlimit_is_not_legal_Should_Return_NOk_TextContent(int actual, int maxSpeed, string expected)
        {
            //Arrange
            Func<int, int, bool> speedChecker = (actSpeed, expSpeed) => { return actSpeed <= expSpeed; };

            //Act
            var result = driver.Drive(speedChecker, actual, maxSpeed).ToLower();

            //Assert
            Assert.Contains(expected, result);
        }


        [Theory]
        [InlineData(9, 30, "cracked")]
        [InlineData(2, 110, "cracked")]
        public void When_driverSpeed_is_limited_to_10_Should_throw_exception(int actual, int maxSpeed, string expected)
        {
            //Arrange
            Func<int, int, bool> speedChecker = (actSpeed, expSpeed) => { return actSpeed <= expSpeed; };

            //Assert
            Assert.Throws<NotSupportedException>(() => driver.Drive(speedChecker, actual, maxSpeed).ToLower());


        }
    }
}