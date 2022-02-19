using KudoCode.Contracts;

namespace KudoCode.LogicLayer.Dtos.Leads
{
	public class CreateLeadsFromCsvDto: IApiRequestDto
	
	{
		public byte[] Document { get; set; }
	}

}