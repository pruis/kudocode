using System.Data.Common;
using System.Threading.Tasks;

namespace KudoCode.Contracts.Api
{
    //https://cpratt.co/truly-generic-repository/
    public interface IRepository : IReadOnlyRepository
    {
        IRepository Save<TEntity>(TEntity entity, string createdBy = null)
            where TEntity : class, IEntity;

        void Create<TEntity>(TEntity entity, string createdBy = null)
            where TEntity : class, IEntity;

        void Update<TEntity>(TEntity entity, string modifiedBy = null)
            where TEntity : class, IEntity;

        void Delete<TEntity>(object id)
            where TEntity : class, IEntity;

        void Delete<TEntity>(TEntity entity)
            where TEntity : class, IEntity;

        void SaveChanges();

        void ExecuteSqlCommand(string command);

        Task SaveAsync();
    }
}