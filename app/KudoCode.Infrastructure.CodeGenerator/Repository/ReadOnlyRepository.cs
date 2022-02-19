using KudoCode.Contracts.Api;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace KudoCode.Infrastructure.CodeGenerator.Repository
{
	public class ReadOnlyRepository : IReadOnlyRepository
	{
		public void Dispose()
		{
			throw new NotImplementedException();
		}

		public void ExecuteStoredProc(string spName, Action<DbDataReader> callBack, Dictionary<string, string> parameters)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<TEntity> Get<TEntity>(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includeProperties = null, int? skip = null, int? take = null) where TEntity : class
		{
			throw new NotImplementedException();
		}

		public void Sql(string sql, Action<DbDataReader> callBack, params object[] parameters)
		{
			throw new NotImplementedException();
		}

		IEnumerable<TEntity> IReadOnlyRepository.GetAll<TEntity>(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includeProperties, int? skip, int? take)
		{
			throw new NotImplementedException();
		}

		Task<IEnumerable<TEntity>> IReadOnlyRepository.GetAllAsync<TEntity>(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includeProperties, int? skip, int? take)
		{
			throw new NotImplementedException();
		}

		Task<IEnumerable<TEntity>> IReadOnlyRepository.GetAsync<TEntity>(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includeProperties, int? skip, int? take)
		{
			throw new NotImplementedException();
		}

		TEntity IReadOnlyRepository.GetById<TEntity>(object id)
		{
			throw new NotImplementedException();
		}

		ValueTask<TEntity> IReadOnlyRepository.GetByIdAsync<TEntity>(object id)
		{
			throw new NotImplementedException();
		}

		int IReadOnlyRepository.GetCount<TEntity>(Expression<Func<TEntity, bool>> filter)
		{
			throw new NotImplementedException();
		}

		Task<int> IReadOnlyRepository.GetCountAsync<TEntity>(Expression<Func<TEntity, bool>> filter)
		{
			throw new NotImplementedException();
		}

		bool IReadOnlyRepository.GetExists<TEntity>(Expression<Func<TEntity, bool>> filter)
		{
			throw new NotImplementedException();
		}

		Task<bool> IReadOnlyRepository.GetExistsAsync<TEntity>(Expression<Func<TEntity, bool>> filter)
		{
			throw new NotImplementedException();
		}

		TEntity IReadOnlyRepository.GetFirst<TEntity>(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includeProperties)
		{
			throw new NotImplementedException();
		}

		Task<TEntity> IReadOnlyRepository.GetFirstAsync<TEntity>(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includeProperties)
		{
			throw new NotImplementedException();
		}

		IQueryable<TEntity> IReadOnlyRepository.GetIQueryable<TEntity>(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includeProperties)
		{
			throw new NotImplementedException();
		}

		TEntity IReadOnlyRepository.GetLast<TEntity>(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includeProperties)
		{
			throw new NotImplementedException();
		}

		TEntity IReadOnlyRepository.GetOne<TEntity>(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includeProperties)
		{
			throw new NotImplementedException();
		}

		Task<TEntity> IReadOnlyRepository.GetOneAsync<TEntity>(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includeProperties)
		{
			throw new NotImplementedException();
		}
	}
}