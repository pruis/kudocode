﻿using KudoCode.Contracts.Api;
using System;
using System.Threading.Tasks;


namespace KudoCode.Infrastructure.CodeGenerator.Repository
{
	public class Repository : ReadOnlyRepository, IRepository
    {
        public IRepository Save<TEntity>(TEntity entity, string createdBy = null) where TEntity : class, IEntity
        {
            throw new NotImplementedException();
        }

        public void Create<TEntity>(TEntity entity, string createdBy = null) where TEntity : class, IEntity
        {
            throw new NotImplementedException();
        }

        public void Update<TEntity>(TEntity entity, string modifiedBy = null) where TEntity : class, IEntity
        {
            throw new NotImplementedException();
        }

        public void Delete<TEntity>(object id) where TEntity : class, IEntity
        {
            throw new NotImplementedException();
        }

        public void Delete<TEntity>(TEntity entity) where TEntity : class, IEntity
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void ExecuteSqlCommand(string command)
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync()
        {
            throw new NotImplementedException();
        }
    }
}