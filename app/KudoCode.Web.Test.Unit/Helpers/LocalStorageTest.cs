using Autofac;
using KudoCode.Contracts.Api;
using KudoCode.Contracts;
using KudoCode.Contracts.Web;
using KudoCode.Infrastructure.AutoFac.Web;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KudoCode.Web.Test.Unit.Helpers
{
	[TestClass]
    public class LocalStorageTest : UnitTestBase
    {
        private IStorage _storage;

        public LocalStorageTest()
        {
        }

        [TestMethod]
        public void SaveAndRead()
        {
            this.RegisterModule(new KudoCodeLocalStorageModule());

            base.Run(
                "LocalStorageTest",
                "",
                "",
                "");
        }

        protected override void Seed()
        {
        }

        protected override void Given()
        {
            _storage = ApplicationContext.Container.Resolve<IStorage>();
        }

        protected override void When()
        {
            _storage.Set("xx", "yy");
        }

        protected override void Then()
        {
            var result = _storage.Get<string>("xx");
            Assert.IsTrue(result.Equals("yy"));
        }
    }
    
    
    [TestClass]
    public class CsrfLocalTokenCacheTest : UnitTestBase
    {
        private ITokenCache _tokenCache;

        [TestMethod]
        public void SaveAndRead()
        {
            this.RegisterModule(new KudoCodeLocalStorageModule());

            base.Run(
                "LocalStorageTest",
                "",
                "",
                "");
        }

        protected override void Seed()
        {
        }

        protected override void Given()
        {
            _tokenCache = ApplicationContext.Container.Resolve<ITokenCache>();
        }

        protected override void When()
        {
            _tokenCache.Set("yy");
        }

        protected override void Then()
        {
            var result = _tokenCache.Get();
            Assert.IsTrue(result.Equals("yy"));
        }
    }
}