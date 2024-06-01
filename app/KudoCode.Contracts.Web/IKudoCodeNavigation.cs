using System.Collections.Generic;
using Microsoft.Extensions.Primitives;

namespace KudoCode.Contracts.Web
{
    public interface IKudoCodeNavigation
    {
        void GoTo(string uri);
        Dictionary<string, StringValues> GetParams();
        string GetParam(string key);
    }
}