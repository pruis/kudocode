using System;

namespace KudoCode.Contracts.Web
{
	public class EndPointConnector
	{
		private Action _onFail;
		private Action _onSuccess;

		private readonly ConnectorClient _connectorClient;

		public EndPointConnector(ConnectorClient connectorClient)
		{
			this._connectorClient = connectorClient;
		}

		public IApiResponseContextDto<TResponseDto> Request<TRequestDto, TResponseDto>(TRequestDto dto)
			where TRequestDto : IApiRequestDto
		{
			var result = ConnectorCalls.EndPoint<TRequestDto, TResponseDto>(_connectorClient, dto);
			return result;
		}

		public EndPointConnector SetOnSuccess(Action onSuccess)
		{
			_onSuccess = onSuccess;
			return this;
		}


		public EndPointConnector SetOnFail(Action onFail)
		{
			_onFail = onFail;
			return this;
		}
	}
}