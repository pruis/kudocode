using KudoCode.LogicLayer.Infrastructure.Dtos;
using KudoCode.LogicLayer.Infrastructure.Dtos.Requests.Interfaces;

namespace KudoCode.LogicLayer.Dtos.Leads
{
	public class CreateLeadsFromCsvDto: IApiRequestDto
	
	{
		public byte[] Document { get; set; }
	}

}