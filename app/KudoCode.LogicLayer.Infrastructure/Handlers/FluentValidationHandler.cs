using System.Collections.Generic;
using System.Linq;
using Autofac;
using FluentValidation;
using KudoCode.LogicLayer.Infrastructure.Execution.Context.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Handlers.Interfaces;
using log4net;

namespace KudoCode.LogicLayer.Infrastructure.Handlers
{
	public class FluentValidationHandler<TRequestDto, TOut> : IHandler<TRequestDto, IValidationContext<TOut>>
	{
		//public ILog Log { get; set; }

		private readonly ILifetimeScope _scope;
		private IValidationContext<TOut> Context;

		public FluentValidationHandler(IValidationContext<TOut> context, ILifetimeScope scope)
		{
			Context = context;
			_scope = scope;
		}

		public IValidationContext<TOut> Handle(TRequestDto request)
		{
			//Log.Debug($"{this.GetType().Name} Handle Start");
			var validators = _scope.Resolve<IEnumerable<IValidator<TRequestDto>>>().ToList();

			foreach (var validator in validators)
			{
				var results = validator.Validate(request);
				if (!results.IsValid)
					results.Errors.ToList().ForEach(error => Context.AddMessage("E6", new[] { error.ErrorMessage }));
			}
			//Log.Debug($"{this.GetType().Name} Handle End");
			return Context;
		}
	}
}