using Autofac;
using KudoCode.Contracts.Api;
using KudoCode.LogicLayer.Dtos;
using KudoCode.Contracts;
using KudoCode.LogicLayer.Plugin.EntityAudit_.Domain.Logic.EntityAudits.Plugin.Factory;
using KudoCode.LogicLayer.Plugin.EntityAudit_.Domain.Logic.EntityAudits.Plugin.Interfaces;
using KudoCode.LogicLayer.Plugin.EntityAudit_.Dtos;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;

namespace KudoCode.LogicLayer.Plugin.EntityAudit_.Domain.Logic.EntityAudits.Plugin
{
	public class
        EntityAuditCommandHandlerPlugin<TRequestDto, TEntity, TOut> : ICommandHandlerDelegates<TRequestDto, TEntity,
            TOut> where TEntity : new()
    {
        private readonly ILifetimeScope _scope;
        private readonly IApplicationUserContext _applicationUserContext;
        private readonly IConfiguration _configuration;
        private readonly IEntityAuditFactory _auditFactory;
        private readonly CommandHandlerDelegates<TRequestDto, TEntity, TOut> _commandHandlerDelegates;

        public EntityAuditCommandHandlerPlugin(
            IEntityAuditFactory auditFactory,
            CommandHandlerDelegates<TRequestDto, TEntity, TOut> commandHandlerDelegates,
            ILifetimeScope scope,
            IApplicationUserContext applicationUserContext,
            IConfiguration configuration
        )
        {
            _scope = scope;
            _applicationUserContext = applicationUserContext;
            _configuration = configuration;
            _auditFactory = auditFactory;
            _commandHandlerDelegates = commandHandlerDelegates;

            _commandHandlerDelegates.BeforeExecute += AuditGetEntity;
            _commandHandlerDelegates.AfterExecute += AuditExecute;
            _commandHandlerDelegates.AfterExecute += CompleteAudit;
        }


        private void AuditGetEntity(IAbstractEntityHandler<TRequestDto, TEntity, TOut> handler)
        {
            CreateTask(handler, "GetEntity");
        }

        private void AuditExecute(IAbstractEntityHandler<TRequestDto, TEntity, TOut> handler)
        {
            CreateTask(handler, "Execute");
        }

        private void CompleteAudit(IAbstractEntityHandler<TRequestDto, TEntity, TOut> handler)
        {
            //_tasks.ForEach(a => a.Wait());

            var entityAudit = _auditFactory.GetDifference(
                $"{handler.Entity.GetType().Name}_GetEntity",
                $"{handler.Entity.GetType().Name}_Execute");
            entityAudit.Wait();

            if (entityAudit.Result.Any())
                handler.Context.RaiseEvent(new CreateEntityAuditEventMessage
                    {
                        PropertyInformation = entityAudit.Result,
                        Entity = handler.Entity.GetType().Name,
                        EntityId = ((IEntity) handler.Entity).Id,
                        CreatedBy = _applicationUserContext.Email,
                        ApplicationUserId = _applicationUserContext.Id,
                        CreatedDate = DateTime.UtcNow.ToString(_configuration["DateTimeFormat"]),
                    }, Constants.EventQueues.InternalEventsQueue
                );
        }

        private void CreateTask(IAbstractEntityHandler<TRequestDto, TEntity, TOut> handler, string taskName)
        {
            if (!_scope.TryResolve(typeof(IAuditDefinition<>).MakeGenericType(new Type[] {typeof(TEntity)}),
                out var definition)) return;

            var result = new object();
            if (handler.Entity != null)
                result = definition.GetType()
                    .GetMethod("GetAudit")
                    .Invoke(definition, new object[] {handler.Entity});

            _auditFactory.Set($"{typeof(TEntity).Name}_{taskName}", result).Wait();
            //_tasks.Add(_auditFactory.Set($"{typeof(TEntity).Name}_{taskName}", result));
        }


        public void Dispose()
        {
            _commandHandlerDelegates.BeforeExecute -= AuditGetEntity;
            _commandHandlerDelegates.AfterExecute -= AuditExecute;
            _commandHandlerDelegates.AfterExecute -= CompleteAudit;
        }
    }
}