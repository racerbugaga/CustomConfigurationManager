using AutoFixture.Idioms;
using AutoFixture.Xunit2;
using CustomConfigurationManager.AppConfig;
using Xunit;

namespace CustomConfigurationManager.Tests.AppConfig
{
    public class AppConfigurationSectionTests
    {
        [Theory, AutoData]
        public void Guard_Success(GuardClauseAssertion assertion)
        {
            assertion.Verify(typeof(AppConfigurationSection));
        }
    }
}