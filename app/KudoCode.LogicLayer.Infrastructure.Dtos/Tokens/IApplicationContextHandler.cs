using KudoCode.LogicLayer.Infrastructure.Dtos.ApplicationUsers.Interface;

namespace KudoCode.LogicLayer.Infrastructure.Dtos.Tokens
{
    public interface IApplicationContextHandler
    {
        IApplicationUserContext SetContext(IApplicationUserContext applicationUserContext);
        IApplicationUserContext FetchContext();
        bool IsLoggedIn();
        void Destroy();
    }

    public interface ITokenCache
    {
        void Set(string token);
        string Get();
    }
}