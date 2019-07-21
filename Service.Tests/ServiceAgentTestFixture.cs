using System;
using Moq;
using NUnit.Framework;
using Service.Impl;

namespace Service.Tests
{
    [TestFixture]
    public class ServiceAgentTestFixture
    {
        private ServiceAgent _unitUnderTest;
        private Mock<IConfigReader> _mockConfigReader;

        [SetUp]
        public void SetUp()
        {
            // a mock config reader that I'm going to use to pass into the unit I'm testing
            _mockConfigReader = new Mock<IConfigReader>();

            // pass the mock into. This is injecting a dependency into so I can control what the dependency is returning to test
            _unitUnderTest = new ServiceAgent(_mockConfigReader.Object);
        }

        [Test]
        public void ReturnOkWhenConfigIsValid()
        {
            // the data I want to return to ServiceAgent.
            var mockedReturnConfig = new ConfigDto {ConfigSource = "ABC", ConfigData = "DEF"};

            // configure Moq to return that whenever someone calls `GetConfigData()'
            _mockConfigReader.Setup(c => c.GetConfigData()).Returns(mockedReturnConfig);

            var reportData = _unitUnderTest.RetrieveReport();
            Assert.That(reportData, Is.EqualTo(mockedReturnConfig.ConfigData));
        }
    }
}
