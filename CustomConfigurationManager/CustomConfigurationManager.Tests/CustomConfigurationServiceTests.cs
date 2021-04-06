using AutoFixture;
using AutoFixture.Idioms;
using AutoFixture.Xunit2;
using CustomConfigurationManager.Tests.TestConfigs;
using Xunit;

namespace CustomConfigurationManager.Tests
{
    public class CustomConfigurationServiceTests
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

        [Fact]
        public void CustomConfigurationService_GetConfigRoot_Success()
        {
            //arrange
            var target = new CustomConfigurationService();

            //act
            var config = target.GetConfig<RootedSection>();

            //assert
            Assert.Equal(1, config.Param1);
            Assert.Equal("Param22", config.Param2);
        }

        [Theory, AutoData]
        public void Guard_Success(GuardClauseAssertion assertion)
        {
            assertion.Verify(typeof(CustomConfigurationService));
        }
    }
}