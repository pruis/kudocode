using Autofac;
using AutoMapper;
using KudoCode.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KudoCode.Contracts.Api
{
	public abstract class DynamicInterceptBase<T, R> : IDynamicInterceptor
	{
		private T _myObject;
		private ILifetimeScope _scope;
		private IExecutionPipelineContext<R> _executionPipelineContext;

		public DynamicInterceptBase(ILifetimeScope scope, IExecutionPipelineContext<R> executionPipelineContext)
		{
			_scope = scope;
			_executionPipelineContext = executionPipelineContext;
		}
		public object Execute(object data)
		{
			GetConcreteType(data);

			if (_executionPipelineContext.HasErrors())
				return _myObject;

			this.Handle(_myObject);
			return _myObject;
		}

		public void Validate(object data)
		{
			GetConcreteType(data);

			var validationHandler = _scope.Resolve<IHandler<T, IValidationContext<T>>>();
			if (validationHandler == null)
				return;

			var context = validationHandler.Handle(_myObject);
			if (context.HasErrors())
				_executionPipelineContext.Messages.AddRange(context.Messages);
		}
		private T GetConcreteType(object data)
		{
			if (_myObject != null)
				return _myObject;

			var json = JsonConvert.SerializeObject(data);
			var myobject = JsonConvert.DeserializeObject<T>(json);
			_myObject = myobject;
			return _myObject;
		}

		public abstract void Handle(T data);
	}
}
