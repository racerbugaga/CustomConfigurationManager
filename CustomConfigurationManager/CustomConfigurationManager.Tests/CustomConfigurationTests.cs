using CustomConfigurationManager.Tests.TestConfigs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CustomConfigurationManager.Tests
{
    [TestClass]
    public class CustomConfigurationTests
    {
        [TestMethod]
        public void CustomConfigurationService_GetConfig_Success()
        {
            //arrange
            var target = new CustomConfigurationService();

            //act
            var config = target.GetConfig<ServersSection>();

            //assert
            Assert.AreEqual(3, config.Parallelism);
            Assert.IsTrue(config.ParallelEnabled);
        }
    }
}
