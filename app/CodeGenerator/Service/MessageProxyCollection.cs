using KudoCode.Contracts.Api;
using KudoCode.Contracts;
using KudoCode.LogicLayer.Dtos;
using System.Collections.Generic;

namespace CodeGenerator.Service
{
	public class MessageProxyCollection : MessageCollection, IMessageCollection
    {
        public IReadOnlyCollection<MessageDto> Messages => base.Messages;
    }
}