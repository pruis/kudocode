using Autofac;

namespace KudoCode.Contracts.Api
{
	public abstract class ExecutionPipelineFilter<TRequestDto, TOut> : IExecutionPipelineFilter<TRequestDto, TOut>
	{
		protected readonly ILifetimeScope Scope;

		protected ExecutionPipelineFilter(ILifetimeScope scope)
		{
			Scope = scope;
		}

		public abstract IExecutionPipelineFilter<TRequestDto, TOut> Participate(TRequestDto requestDto);
	}
}