using KudoCode.LogicLayer.Infrastructure.Dtos.ApplicationUsers;
using KudoCode.LogicLayer.Infrastructure.Dtos.Tokens;
using KudoCode.Web.Infrastructure.Domain.Execution;
using KudoCode.Web.Infrastructure.Domain.HttpConnector;

namespace KudoCode.Web.Infrastructure.Domain.Handlers
{
    public class GetTokenRequestWebHandler : IWebHandler<GetTokenRequest, int>
    {
        private readonly ApiPostController _connector;
        private readonly IApplicationContextHandler _applicationContextHandler;

        public GetTokenRequestWebHandler(ApiPostController connector,
            IApplicationContextHandler applicationContextHandler)
        {
            _connector = connector;
            _applicationContextHandler = applicationContextHandler;
        }

        public IWebResponseDto<int> Handle(GetTokenRequest request,
            IWebResponseDto<int> webResponseDto)
        {
            _connector.Create<GetTokenRequest, ApplicationUserContext>()
                .SetOnSuccess((rsp) => { _applicationContextHandler.SetContext(rsp.Result); })
                .SetOnComplete((rsp) => { webResponseDto.Messages.AddRange(rsp.Messages); })
                .Post(request);
            return webResponseDto;
        }
    }
}