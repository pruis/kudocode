using System;
using System.Linq;
using KudoCode.Contracts;

namespace KudoCode.Contracts.Web
{
    public class WebExecutionPipelineChained<TDto, TOut> where TOut : new()
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IKudoCodeNavigation _navigation;

        private Action<WebResponseDto<TOut>> _onFail;
        private Action<WebResponseDto<TOut>> _onSuccess;

        public WebExecutionPipelineChained(
            IServiceProvider serviceProvider,
            IKudoCodeNavigation navigation
        )
        {
            _serviceProvider = serviceProvider;
            _navigation = navigation;
        }

        public WebExecutionPipelineChained<TDto, TOut> SetOnSuccess(Action<WebResponseDto<TOut>> onSuccess)
        {
            _onSuccess = onSuccess;
            return this;
        }

        public WebExecutionPipelineChained<TDto, TOut> SetOnFail(Action<WebResponseDto<TOut>> onFail)
        {
            _onFail = onFail;
            return this;
        }

        public WebResponseDto<TOut> Execute(TDto dto)
        {
            var webResponseDto = new WebResponseDto<TOut>();
            try
            {
                var handler = _serviceProvider.GetService(typeof(IWebHandler<TDto, TOut>));
                if (handler == null)
                    throw new NullReferenceException("Handler was not found");
                ((IWebHandler<TDto, TOut>) handler).Handle(dto, webResponseDto);
                return webResponseDto;
            }
            catch (Exception e)
            {
                webResponseDto.AddError("EW1", new[] {e.Message});
                return webResponseDto;

            }
            finally
            {
                if (webResponseDto.Messages.Any(a => a.Type == MessageDtoType.Error))
                {
                    if (webResponseDto.Messages.Any(a => a.Key.Equals("E3")))
                        _navigation.GoTo("/LoginRedirect");
                    _onFail?.Invoke(webResponseDto);
                }
                else
                    _onSuccess?.Invoke(webResponseDto);
            }
        }
    }
}