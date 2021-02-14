using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Primitives;

namespace KudoCode.Web.Infrastructure.Domain
{
    public class KudoCodeNavigation : IKudoCodeNavigation
    {
        private readonly NavigationManager _navManager;
        private Dictionary<string, StringValues> _params;

        public KudoCodeNavigation(NavigationManager navManager)
        {
            _navManager = navManager;
        }

        public Dictionary<string, StringValues> GetParams()
        {
            var uri = new Uri(_navManager.BaseUri);

            _params = Microsoft.AspNetCore.WebUtilities.QueryHelpers.ParseQuery(uri.Query);
            return _params;
        }

        public string GetParam(string key)
        {
            return _params.TryGetValue(key, out var type) ? type.First() : "0";
        }

        public void GoTo(string uri)
        {
            _navManager.NavigateTo(uri, true);
        }
    }
}