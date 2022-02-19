using KudoCode.Contracts.Api;
using KudoCode.Contracts.Api;
using System.Collections.Generic;


namespace KudoCode.LogicLayer.Domain.Logic.ImportXls.Entities
{
	public class ImportXlsSheet : IEntity
	{
		public ImportXlsSheet(string name)
		{
			Details = new List<ImportXlsSheetDetail>();
			Name = name;
		}

		public int Id { get; set; }
		public string Name { get; set; }
		public int ImportXlsDocumentId { get; set; }
		public List<ImportXlsSheetDetail> Details { get; set; }

	}
}