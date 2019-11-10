namespace KudoCode.LogicLayer.Plugin.EntityAudit.UnitTests.Base
{
	public interface IUnitTestBase
	{
		void Run(string scenarioTitle, string given, string when, string then);
	}
}