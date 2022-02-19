using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace KudoCode.Contracts.Api
{
    public interface IReadOnlyRepository : IDisposable
    {
        void Sql(string sql, Action<DbDataReader> callBack, params object[] parameters);

        IEnumerable<TEntity> GetAll<TEntity>(
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includeProperties = null,
            int? skip = null,
            int? take = null)
            where TEntity : class, IEntity;

        Task<IEnumerable<TEntity>> GetAllAsync<TEntity>(
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includeProperties = null,
            int? skip = null,
            int? take = null)
            where TEntity : class, IEntity;

        IEnumerable<TEntity> Get<TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includeProperties = null,
            int? skip = null,
            int? take = null)
            where TEntity : class;

        IQueryable<TEntity> GetIQueryable<TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
                        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includeProperties = null
        ) where TEntity : class, IEntity;

        Task<IEnumerable<TEntity>> GetAsync<TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includeProperties = null,
            int? skip = null,
            int? take = null)
            where TEntity : class, IEntity;

        TEntity GetOne<TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
                        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includeProperties = null)
            where TEntity : class, IEntity;

        Task<TEntity> GetOneAsync<TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
                        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includeProperties = null)
            where TEntity : class, IEntity;

        TEntity GetFirst<TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includeProperties = null)
            where TEntity : class, IEntity;

        TEntity GetLast<TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includeProperties = null
            )
            where TEntity : class, IEntity;

        Task<TEntity> GetFirstAsync<TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includeProperties = null)
            where TEntity : class, IEntity;

        TEntity GetById<TEntity>(object id)
            where TEntity : class, IEntity;

        ValueTask<TEntity> GetByIdAsync<TEntity>(object id)
            where TEntity : class, IEntity;

        int GetCount<TEntity>(Expression<Func<TEntity, bool>> filter = null)
            where TEntity : class, IEntity;

        Task<int> GetCountAsync<TEntity>(Expression<Func<TEntity, bool>> filter = null)
            where TEntity : class, IEntity;

        bool GetExists<TEntity>(Expression<Func<TEntity, bool>> filter = null)
            where TEntity : class, IEntity;

        Task<bool> GetExistsAsync<TEntity>(Expression<Func<TEntity, bool>> filter = null)
            where TEntity : class, IEntity;

        void ExecuteStoredProc(string spName, Action<DbDataReader> callBack, Dictionary<string, string> parameters);

    }
}