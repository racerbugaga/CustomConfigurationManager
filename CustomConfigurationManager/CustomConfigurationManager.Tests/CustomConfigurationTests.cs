using CustomConfigurationManager.Tests.TestConfigs;
using Xunit;

namespace CustomConfigurationManager.Tests
{
    public class CustomConfigurationTests
    {
        [Fact]
        public void CustomConfigurationService_GetConfig_Success()
        {
            //arrange
            var target = new CustomConfigurationService("CustomConfiguration");

            //act
            var config = target.GetConfig<ServersSection>();

            //assert
            Assert.Equal(3, config.Parallelism);
            Assert.True(config.ParallelEnabled);
        }

        [Fact]
        public void CustomConfigurationService_GetConfigDefault_Success()
        {
            //arrange
            var target = new CustomConfigurationService();

            //act
            var config = target.GetConfig<ServersSection>();

            //assert
            Assert.Equal(3, config.Parallelism);
            Assert.True(config.ParallelEnabled);
        }
    }
}
