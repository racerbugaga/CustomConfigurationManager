using AutoFixture.Idioms;
using AutoFixture.Xunit2;
using Xunit;

namespace CustomConfigurationManager.Tests
{
    public class CustomConfigurationSectionTests
    {
        [Theory, AutoData]
        public void Guard_Success(GuardClauseAssertion assertion)
        {
            assertion.Verify(typeof(CustomConfigurationSection));
        }
    }
}