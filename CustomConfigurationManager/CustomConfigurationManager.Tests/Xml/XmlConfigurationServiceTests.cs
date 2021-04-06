using AutoFixture.Idioms;
using AutoFixture.Xunit2;
using CustomConfigurationManager.Tests.TestConfigs;
using CustomConfigurationManager.Xml;
using Xunit;

namespace CustomConfigurationManager.Tests.Xml
{
    public class XmlConfigurationServiceTests
    {
        [Fact]
        public void XmlConfigurationService_GetConfig_Success()
        {
            // arrange
            var target = new XmlConfigurationService();

            // act
            var config = target.GetConfig<ServersSection>();

            // assert
            Assert.Equal(3, config.Parallelism);
            Assert.True(config.ParallelEnabled);
        }

        [Theory, AutoData]
        public void Guard_Success(GuardClauseAssertion assertion)
        {
            assertion.Verify(typeof(XmlConfigurationService));
        }
    }
}