using System;
using System.Collections.Generic;
using System.Linq;
using KudoCode.Helpers;
using KudoCode.LogicLayer.Infrastructure.Domain.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Domain.Logic.ApplicationUsers.Entities.Interfaces;

namespace KudoCode.LogicLayer.Infrastructure.Domain.Logic.Lookup.Context
{
    public class ListILookup
    {
        public ListILookup()
        {
            List = AppDomain.CurrentDomain.GetAssemblies()
                .Where(a=>a.FullName.Contains("Domain"))
                .SelectMany(x => x.GetTypes())
                .Where(x => typeof(ILookup).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                .Select(x => new LookupListItem()
                {
                    Name = x.Name,
                    BelongToOrganization = typeof(IBelongToOrganization).IsAssignableFrom(x),
                    IsFilterLookup = typeof(IFilterLookup).IsAssignableFrom(x),
                    IsAuthorizationGroup = IsAuthorizationGroup(x)
                })
                .ToList();
        }

        private static bool IsOrganization(Type type)
        {
            var c = type.IsAssignableFrom(typeof(IBelongToOrganization));
            return c;
        }

        private static bool IsAuthorizationGroup(Type type)
        {
            return type.GetInterfaces()
                .Where(i => i.IsGenericType)
                .Any(i => i.GetGenericTypeDefinition() == typeof(IBelongToAuthorizationGroups<>));
        }


        public List<LookupListItem> List { get; }
    }

    public class LookupListItem
    {
        public string Name { get; set; }
        public bool BelongToOrganization { get; set; }
        public bool IsAuthorizationGroup { get; set; }
        public bool IsFilterLookup { get; set; }
    }
}