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

        public static string? FirstCharToLowerCase(this string? str)
        {
            if (!string.IsNullOrEmpty(str) && char.IsUpper(str[0]))
                return str.Length == 1 ? char.ToLower(str[0]).ToString() : char.ToLower(str[0]) + str[1..];

            return str;
        }
    }
}