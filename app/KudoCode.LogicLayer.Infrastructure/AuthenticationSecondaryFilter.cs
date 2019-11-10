using AutoMapper;
using KudoCode.LogicLayer.Infrastructure.Dtos.ApplicationUsers.Interface;
using KudoCode.LogicLayer.Infrastructure.Execution.Context.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Execution.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Execution.Participants.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Handlers.Interfaces;
using Microsoft.AspNetCore.Http;

namespace KudoCode.LogicLayer.Infrastructure
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

//        public IAuthenticationContext<TOut> Handle(TRequestDto request)
//        {
//            var isLoggedIn = !string.IsNullOrEmpty(_applicationUserContext.Email)
//                             && !string.IsNullOrWhiteSpace(_applicationUserContext.Token?.Value);
//
//            if (!isLoggedIn)
//            {
//                Context.AddMessage("W3");
//                Context.IsValidTokenProvided = false;
//                return Context;
//            }
//
//            Context.IsValidTokenProvided = true;
//            return Context;
//        }

        public IExecutionPipelineFilter<TRequestDto, TOut> Participate(TRequestDto requestDto)
        {
            var isLoggedIn = !string.IsNullOrEmpty(_applicationUserContext.Email)
                             && !string.IsNullOrWhiteSpace(_applicationUserContext.Token?.Value);

            if (!isLoggedIn)
            {
                _context.AddMessage("W3");
                _context.IsValidTokenProvided = false;
                return this;
            }

            _context.IsValidTokenProvided = true;
            return this;
        }
    }
}