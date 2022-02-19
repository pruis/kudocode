using AutoMapper;
using KudoCode.Contracts.Api;
using KudoCode.Contracts;

namespace KudoCode.Web.Test.Unit
{
	public class AuthenticationDummyFilter<TRequestDto, TOut> :
    IExecutionPipelineFilter<TRequestDto, TOut>
    {
        private readonly ISecondaryExecutionPipeline _executionPipeline;
        private readonly IApplicationUserContext _applicationUserContext;
        private readonly IMapper _mapper;
        private readonly IAuthenticationContext<TOut> _context;

        public AuthenticationDummyFilter(IAuthenticationContext<TOut> context,
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
            if (string.IsNullOrEmpty(_applicationUserContext.Token?.Value))
            {
                _context.AddMessage("W3");
                _applicationUserContext.Token.IsValidTokenProvided = false;
                return this;
            }

            //_applicationUserContext.LoginName = "TestAccount";
            _applicationUserContext.Token.IsValidTokenProvided = true;
            return this;
        }
    }
}