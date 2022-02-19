using System.Collections.Generic;

namespace  KudoCode.Contracts
{
	public class MessageProxyCollection : MessageCollection, IMessageCollection
	{
		public IReadOnlyCollection<MessageDto> Messages => base.Messages;
	}


	public class MessageCollection
	{
		public IReadOnlyCollection<MessageDto> Messages => new List<MessageDto>()
		{
			new MessageDto("E1", "{0}", MessageDtoType.Error),
			new MessageDto("E2", "Internal Error please contact support with the following reference. {0}"
				, MessageDtoType.Error),
			new MessageDto("E3", "Authorization Failed {0}", MessageDtoType.Error),
			new MessageDto("W3", "Authorization token not provided", MessageDtoType.Warning),
			new MessageDto("E4","Not found: {0}",MessageDtoType.Error),
			new MessageDto("E5","THIS IS NOT USED {0}",MessageDtoType.Error),
			new MessageDto("E6","Input validation: {0}",MessageDtoType.Error),
			new MessageDto("W6","Input validation: {0}",MessageDtoType.Warning),
		};
	}

	public interface IVxLookup
	{
		int Id { get; set; }
		string Value { get; set; }

	}

	public class VxLookup : IVxLookup
	{
		public VxLookup(int id, string value)
		{
			this.Value = value;
			this.Id = id;
		}
		public VxLookup()
		{
		}
		public int Id { get; set; }
		public string Value { get; set; }

		public override string ToString()
		{
			return Value;
		}
	}

	public class VxLookupList
	{
		public List<VxLookup> List { get; set; }
		public VxLookupList()
		{
			List = new List<VxLookup>();
		}
	}
}
