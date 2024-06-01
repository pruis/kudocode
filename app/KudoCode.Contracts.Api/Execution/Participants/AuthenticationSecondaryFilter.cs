using AutoMapper;
using KudoCode.Contracts;

namespace KudoCode.Contracts.Api
{
	public class AuthenticationSecondaryFilter<TRequestDto, TOut> :
		//        : IHandler<TRequestDto, IAuthenticationContext<TOut>>,
		IExecutionPipelineFilter<TRequestDto, TOut>
	{
		private readonly ISecondaryExecutionPipeline _executionPipeline;
		private readonly IApplicationUserContext _applicationUserContext;
		private readonly IMapper _mapper;
		private readonly IAuthenticationContext<TOut> _context;

		public AuthenticationSecondaryFilter(IAuthenticationContext<TOut> context,
			ISecondaryExecutionPipeline executionPipeline,
			IApplicationUserContext applicationUserContext,
			IMapper mapper)
		{
			_context = context;
			_executionPipeline = executionPipeline;
			_applicationUserContext = applicationUserContext;
			_mapper = mapper;
		}

		public IExecutionPipelineFilter<TRequestDto, TOut> Participate(TRequestDto requestDto)
		{
			var isLoggedIn = !string.IsNullOrEmpty(_applicationUserContext.Email)
							 && !string.IsNullOrWhiteSpace(_applicationUserContext.Token?.Value);

			if (!isLoggedIn)
			{
				_context.AddMessage("W3");
				_applicationUserContext.Token.IsValidTokenProvided = false;
				return this;
			}

			
			_applicationUserContext.Token.IsValidTokenProvided = true;
			return this;
		}
	}
}