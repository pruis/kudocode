using Autofac;
using AutoMapper;
using KudoCode.LogicLayer.Infrastructure.Execution.Context.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Execution.Participants.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Handlers.Interfaces;

namespace KudoCode.LogicLayer.Infrastructure.Execution.Participants
{
	public class CustomValidationParticipant<TRequestDto, TOut> : ExecutionPipelineFilter<TRequestDto, TOut>
	{
		private readonly IMapper _mapper;
		private ICustomValidationContext<TOut> _context;

		public CustomValidationParticipant(IMapper mapper, ICustomValidationContext<TOut> context,ILifetimeScope scope) : base(scope)
		{
			_context = context;
			_mapper = mapper;

		}

		public override IExecutionPipelineFilter<TRequestDto, TOut> Participate(TRequestDto requestDto)
		{
			IHandler<TRequestDto, ICustomValidationContext<TOut>> obj = null;
			if (Scope.TryResolve(out obj))
				obj.Handle(requestDto);

			return this;
		}
	}


}
