using System;
using System.Threading;

namespace KudoCode.Helpers
{
	public class TestHelpers
	{

		static Random r = new Random(new Random(10).Next());
		public static string UniqueName()
		{
			Thread.Sleep(new TimeSpan(0,0,0,0, r.Next(1,100)));
			return $"{DateTime.Now.ToLongTimeString()}{DateTime.Now.Second}{DateTime.Now.Millisecond}{r.Next()}".Replace(".", "")
				.Replace(":", "").Replace(" ", "");
		}
	}
}