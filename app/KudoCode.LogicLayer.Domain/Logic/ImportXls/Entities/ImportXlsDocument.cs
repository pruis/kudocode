using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using KudoCode.LogicLayer.Infrastructure.Domain.Interfaces;

namespace KudoCode.LogicLayer.Domain.Logic.ImportXls.Entities
{
	public class ImportXlsDocument : IEntity, IEntityBasicAudit
	{
		public ImportXlsDocument()
		{
			Sheets = new List<ImportXlsSheet>();
		}

		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public string Name { get; set; }
		public List<ImportXlsSheet> Sheets { get; set; }

		public DateTime CreatedDate { get; set; }
		public string CreatedBy { get; set; }
		public DateTime ModifiedDate { get; set; }
		public string ModifiedBy { get; set; }
	}
}
