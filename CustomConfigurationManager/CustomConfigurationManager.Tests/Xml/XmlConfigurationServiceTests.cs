using System;
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
            var target = new XmlConfigurationService("Xml\\Config.Config");

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

        [Fact]
        public void Test()
        {
            var a = 3;
            var b = 3;
            var c = 3;
            var r1 = a == b;
            var r2 = a == c;
            var r3 = c == b;
            if (r1 && r2)
                Console.WriteLine($"{a} {b} {c}");
            if (r1)
                Console.WriteLine($"{a} {b}");
            else if (r2)
                Console.WriteLine($"{a} {c}");
            else if (r3)
                Console.WriteLine($"{b} {c}");

        }
    }
}