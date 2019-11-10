using System;
using System.Collections.Generic;
using System.Linq;
using KudoCode.LogicLayer.Dtos.Lookups;

namespace KudoCode.LogicLayer.Infrastructure.Dtos
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