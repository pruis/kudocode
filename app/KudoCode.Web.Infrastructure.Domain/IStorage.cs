namespace KudoCode.Web.Infrastructure.Domain
{
    public interface IStorage
    {
        void Set(string key, object result);
        T Get<T>(string key);
        void Remove(string key);
    }
}