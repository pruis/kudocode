using Autofac;
using KudoCode.Contracts;
using log4net;
using System.Collections.Generic;
using System.Linq;

namespace KudoCode.Contracts.Api
{
	public class
		IsLoggedOnAuthorizationHandler<TRequestDto, TOut> : IHandler<TRequestDto, IAuthorizationContext<TOut>>
	{
		protected bool? AllowAnonymous;
		protected readonly IApplicationUserContext ApplicationUserContext;

		public TRequestDto Request { get; set; }
		private readonly IAuthorizationContext<TOut> _context;
		private readonly ILifetimeScope _scope;
		private readonly ILog _log;

		public IsLoggedOnAuthorizationHandler(IApplicationUserContext applicationUserContext,
			IAuthorizationContext<TOut> context, ILifetimeScope scope, ILog log)
		{
			ApplicationUserContext = applicationUserContext;
			_context = context;
			_scope = scope;
			_log = log;
		}

		/// <summary>
		/// When a login is not valid an E3 message is attached to the context and AllowAnonymous set to false
		/// </summary>
		/// <returns></returns>

		public IAuthorizationContext<TOut> Handle(TRequestDto request)
		{
			var isLoggedOn = _context.IsLoggedOn();

			var AuthHandlers = _scope.Resolve<IEnumerable<IHandler<TRequestDto, IAuthorizationContext<TOut>>>>()
				.Where(a => !a.GetType().Name.Contains("IsLoggedOn"));

			if (!isLoggedOn && !AuthHandlers.Any())
				_context.AddMessage("E3", $"Attemped to make anonymous call using: {typeof(TRequestDto)}, {typeof(TOut)} ");
			    //throw new System.NotImplementedException(
			    //    $"Authorization Handler not implemented for: {typeof(TRequestDto)}, {typeof(TOut)}");

			foreach (var handler in AuthHandlers)
			{
				_log.Debug($"{_scope.Tag} - {handler.GetType().Name} - {request.GetType().Name} - start");
				handler.Handle(request);
				_log.Debug($"{_scope.Tag} - {handler.GetType().Name} - {request.GetType().Name} - end");
			}


			return _context;
		}


	}
}