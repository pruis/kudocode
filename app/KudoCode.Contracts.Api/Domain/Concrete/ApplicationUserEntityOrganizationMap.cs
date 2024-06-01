﻿using System;

namespace KudoCode.Contracts.Api
{

	public class ApplicationUserEntityOrganizationMap : IEntity,IEntityBasicAudit
	{
		public int Id { get; set; }

		public int? EntityOrganizationId { get; set; }
		public EntityOrganization EntityOrganization { get; set; }

		public ApplicationUser ApplicationUser { get; set; }
		public int? ApplicationUserId { get; set; }

		public DateTime CreatedDate { get; set; }
		public string CreatedBy { get; set; }
		public DateTime ModifiedDate { get; set; }
		public string ModifiedBy { get; set; }
	}
}