using System;
using System.Collections.Generic;
using System.Linq;

namespace  KudoCode.Contracts
{
    public static class Extensions
    {
        //TODO unit test
        public static List<LookupResponse> AssignLookupValues(GetLookupResponse getLookupResponse, string type)
        {
            return getLookupResponse.Lookups.Where(a => a.Type.Equals(type, StringComparison.InvariantCulture))
                .ToList();
        }
    }
}