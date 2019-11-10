using System;
using System.Linq;
using KudoCode.LogicLayer.Infrastructure.Dtos.ApplicationUsers.Interface;
using KudoCode.LogicLayer.Infrastructure.Execution.Context.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Handlers.Interfaces;

namespace KudoCode.LogicLayer.Infrastructure.Handlers
{
    public abstract class
        AbstractAuthorizationHandler<TRequestDto, TOut> : IHandler<TRequestDto, IAuthorizationContext<TOut>>
    {
        protected bool? AllowAnonymous;
        protected readonly IApplicationUserContext ApplicationUserContext;

        public TRequestDto Request { get; set; }
        public readonly IAuthorizationContext<TOut> Context;

        protected AbstractAuthorizationHandler(IApplicationUserContext applicationUserContext,
            IAuthorizationContext<TOut> context)
        {
            ApplicationUserContext = applicationUserContext;
            this.Context = context;
        }

        protected virtual void Execute()
        {
        }

        /// <summary>
        /// When a login is not valid an E3 message is attached to the context and AllowAnonymous set to false
        /// </summary>
        /// <returns></returns>
        protected bool IsLoggedIn()
        {
            AllowAnonymous = false;
            var isLoggedIn = Context.IsLoggedIn();

            if (isLoggedIn && !Context.Messages.Any(a => a.Key.Equals("E3")))
                return true;

            if (!Context.Messages.Any(a => a.Key.Equals("E3")))
                Context.AddMessage("E3", new[] {$" {this.GetType().Name} User not logged in"});

            return false;
        }

        public IAuthorizationContext<TOut> Handle(TRequestDto request)
        {
            Request = request;

            if (AllowAnonymous == null)
                throw new Exception($" {this.GetType().Name} Auth handler not configured");

            this.Execute();
            return Context;
        }

        /// <summary>
        /// When the group ID is no associated with the current user an E3 message is attached to the Context
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns></returns>
        private bool HasGroup(int groupId)
        {
            AllowAnonymous = false;
            var hasGroup = ApplicationUserContext.AuthorizationGroups.Any(a => a.Id == groupId);

            if (hasGroup)
                return true;

            Context.AddMessage("E3", new[] {$" {this.GetType().Name} User not in required group "});
            return false;
        }

        /// <summary>
        /// When the group ID is no associated with the current user an E3 message is attached to the Context
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns></returns>
        private bool HasRole(int roleId)
        {
            AllowAnonymous = false;
            var hasRole = ApplicationUserContext.AuthorizationRole.Id == roleId;

            if (hasRole)
                return true;

            Context.AddMessage("E3", new[] {$" {this.GetType().Name} User not in required role "});
            return false;
        }
    }
}