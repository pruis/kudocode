using KudoCode.Contracts.Api;
using KudoCode.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace KudoCode.Abstract.Persistence.EntityFramework
{
	public class EntityFrameworkReadOnlyRepository<TContext> : IReadOnlyRepository
		where TContext : DbContext
	{
		protected readonly TContext DbContext;
		protected readonly IApplicationUserContext ApplicationUserContext;

		public EntityFrameworkReadOnlyRepository(TContext context, IApplicationUserContext applicationUserContext)
		{
			this.DbContext = context;
			ApplicationUserContext = applicationUserContext;
		}

		public void Sql(string sql, Action<DbDataReader> callBack, params object[] parameters)
		{
			var dr = DbContext.Database.ExecuteSqlQuery(sql, parameters);
			callBack.Invoke(dr.DbDataReader);
			dr.Dispose();
		}
		public void ExecuteStoredProc(string spName, Action<DbDataReader> callBack, Dictionary<string, string> parameters)
		{
			var @params = parameters.Select(a => $"{a.Key} = '{a.Value}',").Aggregate((i, j) => i + " " + j);
			@params = @params.Remove(@params.Length - 1, 1);
			var dr = DbContext.Database.ExecuteSqlQuery($"{spName} {@params}");
			callBack.Invoke(dr.DbDataReader);
			dr.Dispose();
		}

		protected virtual IQueryable<TEntity> GetQueryable<TEntity>(
			Expression<Func<TEntity, bool>> filter = null,
			Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
			Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> incudedProp = null,
			int? skip = null,
			int? take = null
)	
			where TEntity : class
		{
			IQueryable<TEntity> query = DbContext.Set<TEntity>();

			if (incudedProp != null)
			{
				query = incudedProp(query);
			}

			if (typeof(IBelongToAuthorizationGroups<IBelongToGroup>).IsAssignableFrom(typeof(TEntity)))
			{
				query = query.Where($"EntityOrganizationId = {ApplicationUserContext.ActiveEntityOrganizationId}");
			}
			if (typeof(IBelongToOrganization).IsAssignableFrom(typeof(TEntity)))
				query = query.Where($"EntityOrganizationId = {ApplicationUserContext.ActiveEntityOrganizationId}");
			if (typeof(IBelongToApplicationUser).IsAssignableFrom(typeof(TEntity)))
				query = query.Where($"ApplicationUserId = {ApplicationUserContext.Id}");

			if (filter != null)
			{
				query = query.Where(filter);
			}

			if (orderBy != null)
			{
				query = orderBy(query);
			}

			if (skip.HasValue)
			{
				query = query.Skip(skip.Value);
			}

			if (take.HasValue)
			{
				query = query.Take(take.Value);
			}

			return query;
		}

		public virtual IEnumerable<TEntity> GetAll<TEntity>(
			Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
			Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includeProperties = null,
			int? skip = null,
			int? take = null)
			where TEntity : class, IEntity
		{
			return GetQueryable<TEntity>(null, orderBy, includeProperties, skip, take).ToList();
		}

		public virtual async Task<IEnumerable<TEntity>> GetAllAsync<TEntity>(
			Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
			Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includeProperties = null,
			int? skip = null,
			int? take = null)
			where TEntity : class, IEntity
		{
			return await GetQueryable<TEntity>(null, orderBy, includeProperties, skip, take).ToListAsync();
		}

		public virtual IEnumerable<TEntity> Get<TEntity>(
			Expression<Func<TEntity, bool>> filter = null,
			Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
			Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includeProperties = null,
			int? skip = null,
			int? take = null) where TEntity : class
		{
			var query = GetQueryable<TEntity>(filter, orderBy, includeProperties, skip, take);

			return query.ToList();
		}

		public virtual IQueryable<TEntity> GetIQueryable<TEntity>(Expression<Func<TEntity, bool>> filter = null,
			Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includeProperties = null
		) where TEntity : class, IEntity
		{
			var query = GetQueryable<TEntity>(filter, null, includeProperties, null, null);

			return query;
		}


		public virtual async Task<IEnumerable<TEntity>> GetAsync<TEntity>(
			Expression<Func<TEntity, bool>> filter = null,
			Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
			Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includeProperties = null,
			int? skip = null,
			int? take = null)
			where TEntity : class, IEntity
		{
			return await GetQueryable<TEntity>(filter, orderBy, includeProperties, skip, take).ToListAsync();
		}


		public virtual TEntity GetOne<TEntity>(
			Expression<Func<TEntity, bool>> filter = null,
			Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includeProperties = null
			)
			where TEntity : class, IEntity
		{
			return GetQueryable<TEntity>(filter, null, includeProperties, null, null).SingleOrDefault();
		}

		public virtual TEntity GetOne<TEntity>(
			Expression<Func<TEntity, bool>> filter)
			where TEntity : class, IEntity
		{
			var query = DbContext.Set<TEntity>();
			return query.Where(filter).SingleOrDefault();
		}

		public virtual async Task<TEntity> GetOneAsync<TEntity>(
			Expression<Func<TEntity, bool>> filter = null,
			Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includeProperties = null
			)
			where TEntity : class, IEntity
		{
			return await GetQueryable<TEntity>(filter, null, includeProperties).SingleOrDefaultAsync();
		}

		public virtual TEntity GetFirst<TEntity>(
			Expression<Func<TEntity, bool>> filter = null,
			Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
			Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includeProperties = null
			)
			where TEntity : class, IEntity
		{
			return GetQueryable<TEntity>(filter, orderBy, includeProperties).FirstOrDefault();
		}

		public virtual TEntity GetLast<TEntity>(
			Expression<Func<TEntity, bool>> filter = null,
			Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
			Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includeProperties = null
			)
			where TEntity : class, IEntity
		{
			return GetQueryable<TEntity>(filter, orderBy, includeProperties).LastOrDefault();
		}

		public virtual async Task<TEntity> GetFirstAsync<TEntity>(
			Expression<Func<TEntity, bool>> filter = null,
			Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
			Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includeProperties = null
			)
			where TEntity : class, IEntity
		{
			return await GetQueryable<TEntity>(filter, orderBy, includeProperties).FirstOrDefaultAsync();
		}

		public virtual TEntity GetById<TEntity>(object id)
			where TEntity : class, IEntity
		{
			return DbContext.Set<TEntity>().Find(id);
		}

		public virtual ValueTask<TEntity> GetByIdAsync<TEntity>(object id)
			where TEntity : class, IEntity
		{
			return DbContext.Set<TEntity>().FindAsync(id);
		}

		public virtual int GetCount<TEntity>(Expression<Func<TEntity, bool>> filter = null)
			where TEntity : class, IEntity
		{
			return GetQueryable<TEntity>(filter).Count();
		}

		public virtual Task<int> GetCountAsync<TEntity>(Expression<Func<TEntity, bool>> filter = null)
			where TEntity : class, IEntity
		{
			return GetQueryable<TEntity>(filter).CountAsync();
		}

		public virtual bool GetExists<TEntity>(Expression<Func<TEntity, bool>> filter = null)
			where TEntity : class, IEntity
		{
			return GetQueryable<TEntity>(filter).Any();
		}

		public virtual Task<bool> GetExistsAsync<TEntity>(Expression<Func<TEntity, bool>> filter = null)
			where TEntity : class, IEntity
		{
			return GetQueryable<TEntity>(filter).AnyAsync();
		}

		public void Dispose()
		{
			DbContext.Dispose();
		}
	}
}