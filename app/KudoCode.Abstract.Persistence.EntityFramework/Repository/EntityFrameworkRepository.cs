using KudoCode.Contracts.Api;
using KudoCode.Helpers;
using KudoCode.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace KudoCode.Abstract.Persistence.EntityFramework
{
	public class EntityFrameworkRepository<TContext> : EntityFrameworkReadOnlyRepository<TContext>,  IRepository
        where TContext : DbContext
    {
        public IRepository Save<TEntity>(TEntity entity, string createdBy)
            where TEntity : class, IEntity
        {
            if (entity.Id == 0)
                Create(entity);
            else
                Update(entity);

            return this;
        }

        public virtual void Create<TEntity>(TEntity entity, string createdBy = null)
            where TEntity : class, IEntity
        {
            CreateAudit(entity, createdBy);
            AddApplicationUser(entity);
            AddEntityOrganization(entity);

            var dbset = DbContext.Set<TEntity>();
            dbset.Add(entity);
        }

        public virtual void Update<TEntity>(TEntity entity, string modifiedBy = null)
            where TEntity : class, IEntity
        {
            ModifyAudit(entity, modifiedBy);
            DbContext.Set<TEntity>().Attach(entity);
            DbContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete<TEntity>(object id)
            where TEntity : class, IEntity
        {
            TEntity entity = DbContext.Set<TEntity>().Find(id);
            Delete(entity);
        }

        public virtual void Delete<TEntity>(TEntity entity)
            where TEntity : class, IEntity
        {
            var dbSet = DbContext.Set<TEntity>();
            if (DbContext.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }

            dbSet.Remove(entity);
        }

        public virtual void SaveChanges()
        {
            DbContext.SaveChanges();
        }

        public void ExecuteSqlCommand(string command)
        {
            //var r = DbContext.Database.ExecuteSqlCommand(command);
        }

        public virtual Task SaveAsync()
        {
            try
            {
                return DbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw;
                //ThrowEnhancedValidationException(e);
            }

            return Task.FromResult(0);
        }


        private void CreateAudit<TEntity>(TEntity entity, string createdBy) where TEntity : class, IEntity
        {
            if (!entity.IsType<IEntityBasicAudit>()) return;

            ((IEntityBasicAudit) entity).ModifiedDate = DateTime.UtcNow;
            ((IEntityBasicAudit) entity).CreatedDate = DateTime.UtcNow;
            ((IEntityBasicAudit) entity).CreatedBy = ApplicationUserContext?.Email;
            ;
        }

        private void ModifyAudit<TEntity>(TEntity entity, string modifiedBy) where TEntity : class, IEntity
        {
            if (!entity.IsType<IEntityBasicAudit>()) return;

            ((IEntityBasicAudit) entity).ModifiedDate = DateTime.UtcNow;
            ((IEntityBasicAudit) entity).ModifiedBy = ApplicationUserContext.Email;
        }

        private void AddApplicationUser<TEntity>(TEntity entity)
        {
            if (entity.IsType<IBelongToApplicationUser>())
                (entity as IBelongToApplicationUser).ApplicationUserId = ApplicationUserContext.Id;
        }

        private void AddEntityOrganization<TEntity>(TEntity entity)
        {
            if (entity.IsType<IBelongToOrganization>())
                (entity as IBelongToOrganization).EntityOrganizationId =
                    ApplicationUserContext.ActiveEntityOrganizationId;
        }


        public EntityFrameworkRepository(TContext context, IApplicationUserContext applicationUserContext) : base(
            context, applicationUserContext)
        {
        }
    }
}