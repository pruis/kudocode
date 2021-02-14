namespace KudoCode.Web.Infrastructure.Domain
{
	public class ResponseRedirect
	{
		public ResponseRedirect(string actionValue, string action, string title)
		{
			ActionValue = actionValue;
			Action = action;
			Title = Title;
		}

		public string Title { get; set; }
		public string ActionValue { get; set; }
		public string Action{ get; set; }

	}
}