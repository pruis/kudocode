namespace KudoCode.Abstract.Application
{
	public class GetLookupRequestContext : IGetLookupRequestContext
	{
		public ListILookup Lookups { get; }

		public GetLookupRequestContext(ListILookup lookups)
		{
			Lookups = lookups;
		}
	}
}