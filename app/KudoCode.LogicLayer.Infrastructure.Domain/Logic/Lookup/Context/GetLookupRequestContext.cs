namespace KudoCode.LogicLayer.Infrastructure.Domain.Logic.Lookup.Context
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