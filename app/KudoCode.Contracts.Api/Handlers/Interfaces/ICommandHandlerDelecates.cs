using System;
using Autofac.Core;

namespace KudoCode.Contracts.Api
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