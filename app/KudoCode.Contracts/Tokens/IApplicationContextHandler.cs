namespace KudoCode.Contracts
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