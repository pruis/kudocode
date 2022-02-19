using Autofac;
using KudoCode.Abstract.Web.Blazor;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KudoCode.Web.Test.Unit.Helpers
{
    [TestClass]
    public class ConfigReaderUnitTest : UnitTestBase
    {
        private EnvironmentChooser _config;
        private ContainerBuilder _builder;
        private ConfigurationBuilder _configBuilder;

        [TestMethod]
        public void read()
        {
            base.Run(
                "Helpers",
                "",
                "",
                "");
        }

        protected override void Seed()
        {
        }

        protected override void Given()
        {
        }

        protected override void When()
        {
            _configBuilder = Reader.ConfigurationBuilder<UnitTestBase>(() =>
                new EnvironmentChooser("development")
                    .Add("localhost", "development")
                    .Add("kudocode.me", "Production", false));
        }

        protected override void Then()
        {
            Assert.IsTrue(_configBuilder.Sources.Count > 1);
            //Assert.IsTrue(_configBuilder.Build()["ApiBaseUrl"].Contains("localhost"));
        }
    }
}