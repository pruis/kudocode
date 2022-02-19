using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KudoCode.Test.Unit.Helpers
{
    [TestClass]
    public class HelpersUnitTest : UnitTestBase
    {
        [TestMethod]
        public void ImportPortfolio()
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
            var s = "0.02";
            var x = decimal.Parse(s, CultureInfo.InvariantCulture);
            Assert.IsTrue(x == 0.02m);

            var r = decimal.TryParse(s, NumberStyles.Any, CultureInfo.InvariantCulture, out _);
            Assert.IsTrue(r);
        }

        protected override void When()
        {
        }

        protected override void Then()
        {
        }
    }
}