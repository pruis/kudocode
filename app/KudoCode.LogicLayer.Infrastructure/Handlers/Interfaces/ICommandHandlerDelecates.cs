using System;
using Autofac.Core;

namespace KudoCode.LogicLayer.Infrastructure.Handlers.Interfaces
{
	public interface ICommandHandlerDelegates<TRequestDto, TEntity, TOut>: IDisposable
	{
	}
	public interface IQueryHandlerDelegates<TRequestDto, TEntity, TOut> : IDisposable
	{
	}
	public interface IWorkerHandlerDelegates<TRequestDto, TOut> : IDisposable
	{
	}
}